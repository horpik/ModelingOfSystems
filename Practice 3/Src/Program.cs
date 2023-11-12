using System;
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
            // double[] mean = { 10 };
            // double[] stddev = { 2 };
            int numPoints = 1000;
            CreateGraphsNormalDistribution(mean, stddev, numPoints);
        }

        private static void CreateGraphsNormalDistribution(double[] mean, double[] stddev, int numPoints)
        {
            for (int i = 0; i < mean.Length; i++)
            {
                var x = Generate.LinearSpaced(numPoints, -20 * stddev[i], 20 * stddev[i]);
                var y = x.Select(val => NormalDistribution.PDF(val, mean[i], stddev[i])).ToArray();
                
                // var x = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
                // var y = x.Select(val => NormalDistribution.PDF(val, mean[i], stddev[i])).ToArray();
                
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