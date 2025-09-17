public class HippoThread : AnimalsThread
{
    public HippoThread(WaterResource waterResource)
    {
        this.waterResource = waterResource;
        this.type = AnimalType.Hippo;
        this.DrinkTimeMu = 5; // average drink time in seconds
        this.SizeInSlots = 1;   // flamingo takes 1 slot
    }
    /// <summary>
    /// Flamingo can enter only if there's an adjacent flamingo in the lake.
    /// </summary>

}
