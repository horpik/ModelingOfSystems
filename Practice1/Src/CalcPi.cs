namespace Practice1;

public static class CalcPi
{
    /*
    x0, y0 - координаты центра окружности; r0 - радиус окружности
    experimentNumber - число экспериментов для генератора случайных чисел
    */
    public static double CalculatePi(double x0, double y0, double r0, int numberExperiments)
    {
        var xMin = x0 - r0;
        var xMax = x0 + r0;
        var yMin = y0 - r0;
        var yMax = y0 + r0;
        double numberOfPositiveOutcomes = 0;

        var rand = new Random();
        for (var i = 0; i < numberExperiments; i++)
        {
            var randomNumber = rand.NextDouble();
            var x = (xMax - xMin) * randomNumber + xMin;
            randomNumber = rand.NextDouble();
            var y = (yMax - yMin) * randomNumber + yMin;
            if (Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2) < Math.Pow(r0, 2))
            {
                numberOfPositiveOutcomes++;
            }
        }
        return numberOfPositiveOutcomes / numberExperiments * 4;
    }
}