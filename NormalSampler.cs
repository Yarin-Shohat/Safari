public static class NormalSampler
{
    private static readonly Random rnd = new();

    public static double Sample(double mu)
    {
        double stdDev = 1;
        return Sample(mu, stdDev);
    }

    public static double Sample(double mu, double stdDev)
    {
        // Box-Muller transform
        double u1 = 1.0 - rnd.NextDouble();
        double u2 = 1.0 - rnd.NextDouble();
        double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        return mu + stdDev * z;
    }
}
