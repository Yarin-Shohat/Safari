using System;
using System.Collections.Generic;
using System.Threading;

public class LakeManager : WaterResourceManager
{
    readonly object queueLock = new();
    readonly Queue<AnimalsThread> queue = new();

    int freeUnits;         // slots left
    bool hippoActive = false;

    public LakeManager(WaterResource resource) : base(resource)
    {
        freeUnits = resource.getCapacity();
    }

    public override void RequestAccess(AnimalsThread animal)
    {
        // each animal runs its own handler thread
        new Thread(() =>
        {
            if (animal.type == AnimalType.Hippo)
                HandleHippo(animal);
            else
                HandleRegular(animal);
        })
        { IsBackground = true }.Start();
    }

    private void HandleRegular(AnimalsThread a)
    {
        int need = a.SizeInSlots;
        bool entered = false;

        lock (queueLock)
        {
            queue.Enqueue(a);
            while (true)
            {
                // 1) hippo not drinking
                if (hippoActive)
                { Monitor.Wait(queueLock); continue; }

                // 2) must be at head
                if (queue.Count != 0 && queue.Peek() != a)
                    { Monitor.Wait(queueLock); continue; }

                // 3) enough freeUnits
                if (freeUnits < need)
                { Monitor.Wait(queueLock); continue; }

                // 4) flamingo adjacency
                if (a.type == AnimalType.Flamingo && !FlamingoCanEnter())
                { Monitor.Wait(queueLock); continue; }

                // all good ? occupy
                freeUnits -= need;
                PlaceAnimalInArray(a);
                if (queue.Count != 0)
                    queue.Dequeue();
                entered = true;
                UpdateUI();
                break;
            }
        }

        // drink outside lock
        a.Drink();

        lock (queueLock)
        {
            if (entered)
            {
                RemoveAnimalFromArray(a);
                freeUnits += need;
                UpdateUI();
                Monitor.PulseAll(queueLock);
            }
        }
    }

    private void HandleHippo(AnimalsThread h)
    {
        lock (queueLock)
        {
            // wait for lake to be empty & no other hippo
            while (hippoActive || freeUnits != ResourceCapacity)
                Monitor.Wait(queueLock);
            hippoActive = true;
            queue.Clear();
            ClearAllAnimalsFromArray();
            Console.WriteLine($"Hippo enters Lake {waterResource.getId()} exclusively");
            PlaceAnimalInArray(h);
            UpdateUI();
            h.Drink();

        }


        lock (queueLock)
        {
            hippoActive = false;
            freeUnits = ResourceCapacity;
            RemoveAnimalFromArray(h);
            Console.WriteLine($"Hippo leaves Lake {waterResource.getId()}");

            UpdateUI();
            Monitor.PulseAll(queueLock);
        }
    }

    private bool FlamingoCanEnter()
    {
        // same adjacency logic you already had
        var arr = waterResource.getAnimals();
        int used = ResourceCapacity - freeUnits;
        if (used == 0) return true;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i]?.type == AnimalType.Flamingo)
                if ((i > 0 && arr[i - 1] == null) ||
                    (i < arr.Length - 1 && arr[i + 1] == null))
                    return true;
        return false;
    }

    private void PlaceAnimalInArray(AnimalsThread a)
    {
        int slots = a.SizeInSlots;
        // If Hippo Take all the place
        if (a.type == AnimalType.Hippo)
            slots = this.waterResource.capacity;
        var arr = waterResource.animals;
        for (int i = 0; i < arr.Length && slots > 0; i++)
        {
            if (arr[i] == null)
            {
                arr[i] = a;
                waterResource.currentCount++;
                slots--;
            }
        }
    }

    private void RemoveAnimalFromArray(AnimalsThread a)
    {
        var arr = waterResource.animals;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == a)
            {
                arr[i] = null;
                waterResource.currentCount--;
            }
        }
    }

    private void ClearAllAnimalsFromArray()
    {
        Array.Clear(waterResource.animals, 0, waterResource.animals.Length);
        waterResource.currentCount = 0;
    }

    private void UpdateUI()
    {
        Action<AnimalsThread[], int> AnimalsUpdatedEvent = getAnimalsUpdated();
        AnimalsUpdatedEvent?.Invoke((AnimalsThread[])waterResource.animals.Clone(),waterResource.getId());
    }

    private int ResourceCapacity => waterResource.getCapacity();
}


//using System;
//using System.Collections.Generic;
//using System.Threading;


//public class LakeManager : WaterResourceManager
//{
//    public List<AnimalsThread> WaitingAnimals;

//    public LakeManager(WaterResource resource) : base(resource)
//    {

//    }

//    // Called by animal threads to request access to the lake.
//    public override void RequestAccess(AnimalsThread Animal)
//    {
//        // Implement the logic to request access to the lake.
//        // This may involve checking if the lake is available and managing the queue of animals.
//        Console.WriteLine($"{Animal.type} is requesting access to the lake {Animal.waterResource.getId()}.");

//        AnimalsThread[] animalsArr = this.waterResource.animals;
//        WaterResource resource = this.waterResource;

//        animalsArr[this.waterResource.getCurrentCount()] = Animal;
//        Action<AnimalsThread[], int> AnimalsUpdatedEvent = getAnimalsUpdated();
//        AnimalsUpdatedEvent?.Invoke((AnimalsThread[])animalsArr.Clone(), resource.getId());
//        Console.WriteLine($"{animalsArr[this.waterResource.getCurrentCount()]} IN ARR");

//        Animal.Drink();
//        Console.WriteLine($"{Animal.type} is finished drinking from  lake {Animal.waterResource.getId()}.");
//        // Simulate some processing time
//    }


//}
