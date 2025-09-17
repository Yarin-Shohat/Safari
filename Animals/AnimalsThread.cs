
public abstract class AnimalsThread
{
    public double DrinkTimeMu; // Avg drink time (sec)
    public int SizeInSlots; // Space needed in lake
    public WaterResource waterResource; // Assigned lake
    public AnimalType type; // Type of animal

    public void Drink()
    {
        Thread.Sleep((int)(NormalSampler.Sample(DrinkTimeMu) * 1000));
    }
    /// <summary>
    /// Lifecycle of a flamingo: wait, try to enter, drink, leave.
    /// </summary>
    public void Run()
    {
        waterResource.requestAccess(this);
    }                          // Animal lifecycle logic

    public override string ToString()
    {
        return type.ToString();
    }
}
