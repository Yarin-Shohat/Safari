using System;
using System.Collections.Generic;
using System.Threading;

 public enum AnimalType
    {
        Flamingo,
        Zebra,
        Hippo
    }
class Safari1
{
    // This class represents a safari that can hold a certain number of lakes.
    public int size; // The maximum number of lakes the safari can hold
    public WaterResource[] WaterResources; // The array of lakes in the safari

    // Threads for generating different types of animals
    private Thread flamingoThread;
    private Thread zebraThread;
    private Thread hippoThread;

    // Global cancellation token to stop all animal generators
    private CancellationTokenSource cts = new();

    //Constructor that initializes the safari with a specified lake capacity list
    public Safari1(List<int> capacity)
    {
        // Check if the capacity list is valid
        if (capacity == null || capacity.Count == 0)
        {
            throw new ArgumentException("Capacity list must not be null or empty");
        }

        // Initialize the size and create the lakes array
        this.size = capacity.Count;
        this.WaterResources = new Lake[capacity.Count];

        // Initialize each lake with the specified capacity
        for (int i = 0; i < size; i++)
        {
            this.WaterResources[i] = new Lake(capacity[i], i);
        }
    }

    // Starts the animal generation threads
    public void Start()
    {
        // Each thread generates a specific animal with arrival time drawn from a normal distribution

        flamingoThread = new Thread(() => AnimalLoop("Flamingo", 2.0));
        zebraThread = new Thread(() => AnimalLoop("Zebra", 3.0));
        hippoThread = new Thread(() => AnimalLoop("Hippo", 10.0));

        flamingoThread.Start();
        zebraThread.Start();
        hippoThread.Start();
    }

    // Stops all running threads by cancelling their tokens
    public void Stop()
    {
        cts.Cancel();
    }

    // The loop that runs in each animal generator thread
    private void AnimalLoop(string name, double muArrival)
    {
        while (!cts.IsCancellationRequested)
        {
            // Generate a delay time based on a normal distribution
            double delay = NormalSampler.Sample(muArrival);

            // Sleep for the generated time (converted to milliseconds)
            Thread.Sleep((int)(Math.Max(0, delay) * 1000));

            // get lake index randomnly
            Random rnd = new();
            int randomIndex = rnd.Next(this.size);

            // Print the animal name and timestamp
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {name} - lake {randomIndex}");
            AnimalsThread animal = null;
            switch (name)
            {
                case "Zebra":
                    animal = new ZebraThread(this.WaterResources[randomIndex]);
                    break;
                case "Hippo":
                    animal = new HippoThread(this.WaterResources[randomIndex]);
                    break;
                case "Flamingo":
                    animal = new FlamingoThread(this.WaterResources[randomIndex]);
                    break;
                default:
                    Console.WriteLine($"NULL IN ARRAY");
                    break;
            }
            animal.Run();
        }
    }
}
