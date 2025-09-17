public class FlamingoThread: AnimalsThread
{
    public FlamingoThread(WaterResource waterResource)
    {
        this.waterResource = waterResource;
        this.type = AnimalType.Flamingo;
        this.DrinkTimeMu = 3.5; // average drink time in seconds
        this.SizeInSlots = 1;   // flamingo takes 1 slot
    }
    /// <summary>
    /// Flamingo can enter only if there's an adjacent flamingo in the lake.
    /// </summary>

}
