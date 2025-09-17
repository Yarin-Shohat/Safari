public class ZebraThread : AnimalsThread
{
    public ZebraThread(WaterResource waterResource)
    {
        this.waterResource = waterResource;
        this.type = AnimalType.Zebra;
        this.DrinkTimeMu = 5; // average drink time in seconds
        this.SizeInSlots = 2;   // zebra takes 2 slot
    }
    /// <summary>
    /// Flamingo can enter only if there's an adjacent flamingo in the lake.
    /// </summary>
}
