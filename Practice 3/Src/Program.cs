using System.Linq;
using ScottPlot;
using Generate = MathNet.Numerics.Generate;

namespace Practice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double mean = 0;
            double stddev = 1;
            int numPoints = 1000;
            var x = Generate.LinearSpaced(numPoints, -3 * stddev, 3 * stddev);
            var y = x.Select(val => NormalDistribution.PDF(val, mean, stddev)).ToArray();

            var plt = new Plot(600, 400);
            plt.PlotScatter(x, y);
            plt.SaveFig("normal_distribution.png");

            plt.SaveFig("D:\\Dev\\Projects\\C#\\ModelingOfSystems\\Practice 3\\Graphics\\normal_distribution.png");
        }
    }
}