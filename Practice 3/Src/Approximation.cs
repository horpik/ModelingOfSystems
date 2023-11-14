using System;

namespace Practice_3
{
    public static class Approximation
    {
        public static double[] PiecewiseLinear(int xAmount)
        {
            Random rnd = new Random();
            double[] x = new double[xAmount];
            int[] m = new int[xAmount];
            double[] a = new double[100];

            for (int i = 0; i < xAmount; i++)
            {
                x[i] = rnd.NextDouble();
                m[i] = Convert.ToInt32(Math.Truncate(100 * x[i]));
            }

            for (int i = 0; i < 100; i++)
            {
                a[i] = i * 0.2;
            }

            double[] y = new double[x.Length-1];
            
            for (int i = 1; i < x.Length; i++)
            {
                y[i-1] = (a[m[i-1]] + (a[m[i]] - a[m[i-1]]) * x[i]);
            }
            
            return y;
        }
    }
}