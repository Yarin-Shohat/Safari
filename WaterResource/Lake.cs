class Lake : WaterResource
{
    // This class represents a lake that can hold a certain number of animals.

    // Constructor that initializes the lake with a specified capacity
    public Lake(int capacity, int id) : base(id, null, capacity)
    {
        this.manager = new LakeManager(this);
        // Check if the capacity is valid (greater than 0)
        if (capacity <= 0)
        {
            throw new ArgumentException("Capacity must be greater than 0");
        }
    }

    // ########## Getters Functions

    // Function for get ID of Lake
    public int getID()
    {
        return base.getId();
    }

    public override WaterResourceManager getManager()
    {
        return manager;
    }

}