public abstract class WaterResourceManager
{
    public WaterResource waterResource;
    public event Action<AnimalsThread[], int> AnimalsUpdated;
    //ConcurrentQueue<AnimalsThread> animalsQueue = new ConcurrentQueue<AnimalsThread>();


    public WaterResourceManager(WaterResource waterResource)
    {
        this.waterResource = waterResource;
    }

    public abstract void RequestAccess(AnimalsThread waitingAnimal);

    public Action<AnimalsThread[], int> getAnimalsUpdated()
    {
        return AnimalsUpdated;
    }

}