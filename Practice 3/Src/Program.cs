using System.Linq;
using ScottPlot;
using Generate = MathNet.Numerics.Generate;

namespace Practice_3
{
    class Program
    {
        static void Main()
        {
            double[] mean = { 10, 10, 10, 12 };
            double[] stddev = { 2, 1, 0.5, 1 };
            int numPoints = 1000;
            CreateGraphsNormalDistribution(mean, stddev, numPoints);
        }

        private static void CreateGraphsNormalDistribution(double[] mean, double[] stddev, int numPoints)
        {
            for (int i = 0; i < mean.Length; i++)
            {
                var x = Generate.LinearSpaced(numPoints, -3 * stddev[i], 3 * stddev[i]);
                var y = x.Select(val => NormalDistribution.PDF(val, mean[i], stddev[i])).ToArray();
                GeneratePlot(x, y, $"normal_distribution{i}");
            }
        }

        private static void GeneratePlot(double[] x, double[] y, string fileName)
        {
            var plt = new Plot(600, 400);
            plt.PlotScatter(x, y);

            plt.SaveFig($"..\\..\\Graphics\\{fileName}.png");
        }
    }
}