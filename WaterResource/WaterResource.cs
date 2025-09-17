public abstract class WaterResource
{
    public int id; // The unique identifier for the lake
    public WaterResourceManager manager;
    public AnimalsThread[] animals; // Array of animals currently drinking from the lake]
    public int currentCount; // The current number of animals in the lake
    public int capacity; // The maximum number of animals the lake can hold

    public WaterResource(int id, WaterResourceManager manager, int capacity)
    {
        this.id = id;
        this.manager = manager;
        this.animals = new AnimalsThread[capacity];
        this.capacity = capacity;
        this.currentCount = 0; // Initialize current count to 0
    }

    public int getId()
    {
        return id;
    }

    public abstract WaterResourceManager getManager();

    public void requestAccess(AnimalsThread animal)
    {
        manager.RequestAccess(animal);
    }

    // Function for get current taken slots
    public int getCurrentCount()
    {
        return currentCount;
    }

    // Function for get Animals array
    public AnimalsThread[] getAnimals()
    {
        return this.animals;
    }

    // Function for get the capacity of the lake
    public int getCapacity()
    {
        return capacity;
    }

}