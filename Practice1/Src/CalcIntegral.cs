namespace Practice1;

public static class CalcIntegral
{
    public static double CalculateIntegral(double a, double b, Func<double, double> func, int numberExperiments)
    {
        var xMin = a;
        var xMax = b;
        var yMin = 0;
        var yMax = func(b);
        double numberOfPositiveOutcomes = 0;
        
        var rand = new Random();
        for (int i = 0; i < numberExperiments; i++)
        {
            
            var randomNumber = rand.NextDouble();
            var x = (xMax - xMin) * randomNumber + xMin;
            randomNumber = rand.NextDouble();
            var y = (yMax - yMin) * randomNumber + yMin;
            if (func(x) > y)
            {
                numberOfPositiveOutcomes++;
            }
        }

        return numberOfPositiveOutcomes / numberExperiments * (b - a) * func(b);
    }
}