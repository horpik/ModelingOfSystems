using MathNet.Numerics.Distributions;

namespace Practice_3
{
    public static class NormalDistribution
    {
        public static double PDF(double x, double mean, double stddev)
        {
            var normal = new Normal(mean, stddev);
            return normal.Density(x);
        }
    }
}