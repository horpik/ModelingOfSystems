using System;
using System.Linq;
using ScottPlot;
using ScottPlot.Statistics;
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
            
            CreateGraphsNormalDistribution(mean, stddev, 1000);
            CreateGraph();
            
            AverageQuadraticErrorWithGraphs();
        }

        private static void CreateGraphsNormalDistribution(double[] mean, double[] stddev, int numPoints)
        {
            for (int i = 0; i < mean.Length; i++)
            {
                var x = Generate.LinearSpaced(numPoints, -20 * stddev[i], 20 * stddev[i]);
                var y = x.Select(val => NormalDistribution.PDF(val, mean[i], stddev[i])).ToArray();

                GeneratePlot(x, y, $"Task1/normal_distribution{i}");
            }
        }

        private static void CreateGraph()
        {
            var x = Generate.LinearSpaced(100, 0, 20);
            var y = x.Select(val => NormalDistribution.PDF(val, 10, 2)).ToArray();

            GeneratePlot(x, y, $"Task2/normal_distribution{20}");
        }

        private static void GeneratePlot(double[] x, double[] y, string fileName)
        {
            var plt = new Plot(2560, 1440);
            plt.PlotScatter(x, y);
            
            plt.SaveFig($"/Users/akvalin/Documents/ModelingOfSystems/ModelingOfSystems/Practice 3/Graphics/{fileName}.png");
        }

        private static void CreateHist(double[] values, string fileName)
        {
            var plt = new Plot(2560, 1440);
            ScottPlot.Statistics.Histogram histogram = new Histogram(-20, 40, 100);
            histogram.AddRange(values);
            plt.AddBar(histogram.Counts, histogram.Bins);
            plt.SaveFig(
                $"/Users/akvalin/Documents/ModelingOfSystems/ModelingOfSystems/Practice 3/Graphics/Task4/{fileName}.png");
        }

        private static double CalculateAverageQuadraticError(double[] values)
        {
            double avg = values.Average();
            double sum = 0;
            
            foreach (var value in values)
            {
                sum += Math.Pow(value - avg, 2);
            }

            return Math.Sqrt(sum / values.Length - 1);
        }


        private static void AverageQuadraticErrorWithGraphs()
        {
            double[] errors = new double[5];
            double[] length = new double[5];
            int counter = 0;
            
            for (int i = 100; i <= 1000000; i=i*10)
            {
                double[] yValues = Approximation.PiecewiseLinear(i);
                CreateHist(yValues, $"hist{i}");
                double error = CalculateAverageQuadraticError(yValues);
                errors[counter] = error;
                length[counter] = i;
                counter++;
            }
            
            GeneratePlot(length, errors, "Task5/errors");
        }
    }
}