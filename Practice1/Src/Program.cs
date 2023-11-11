namespace Practice1;

internal abstract class Program
{
    static void Main(string[] args)
    {
        #region Calc Pi

        double x0 = 1;
        double y0 = 2;
        double r0 = 5;
        int numberCalculationPiSeries = 5;
        List<int> listNumberExperimentsPi = new List<int>()
        {
            (int)Math.Pow(10, 4),
            (int)Math.Pow(10, 5),
            (int)Math.Pow(10, 6),
            (int)Math.Pow(10, 7),
            (int)Math.Pow(10, 8)
        };
        var seriesCalculatePi = InitSeriesCalculatePi(x0, y0, r0, numberCalculationPiSeries, listNumberExperimentsPi);

        #region Test InitSeriesCalculatePi

        for (int i = 0; i < seriesCalculatePi.Count; i++)
        {
            Console.WriteLine($"Серия {i}: ");
            for (int j = 0; j < seriesCalculatePi[i].Count; j++)
            {
                if (j != seriesCalculatePi[i].Count - 1)
                {
                    Console.Write(seriesCalculatePi[i][j] + ", ");
                }
                else
                {
                    Console.WriteLine(seriesCalculatePi[i][j]);
                }
            }
        }

        Console.WriteLine();

        #endregion

        var listEpsSeriesResultsPi = InitCalculateCalculationEps(seriesCalculatePi);


        var listAverageResultsPi = InitListAverageResults(listNumberExperimentsPi.Count, seriesCalculatePi);


        var listEpsAverageResultsPi = InitListEpsAverageResults(listAverageResultsPi);

        #endregion


        #region Calc Integral

        double a = 0; // нижняя граница
        double b = 2; // верхняя граница
        int numberCalculationIntegralSeries = 3; // количество серий
        var listNumberExperimentsIntegral = new List<int>() // инициализация серий
        {
            (int)Math.Pow(10, 4),
            (int)Math.Pow(10, 5),
            (int)Math.Pow(10, 6)
        };
        double FuncForIntegral(double tmp) => Math.Pow(tmp, 3) + 1; // функция для интеграла
        var seriesCalculateIntegral = InitSeriesCalculateIntegral(a, b, FuncForIntegral,
            numberCalculationIntegralSeries, listNumberExperimentsIntegral);

        var listEpsSeriesResultsIntegral = InitCalculateCalculationEps(seriesCalculateIntegral);

        var listAverageResultsIntegral =
            InitListAverageResults(listNumberExperimentsIntegral.Count, seriesCalculateIntegral);

        var listEpsAverageResultsIntegral = InitListEpsAverageResults(listAverageResultsIntegral);

        #endregion
    }

    private static List<List<double>> InitSeriesCalculateIntegral(double a, double b, Func<double, double> func,
        int numberCalculationSeries,
        List<int> listNumberExperiments)
    {
        var result = new List<List<double>>();
        for (int i = 0; i < numberCalculationSeries; i++)
        {
            result.Add(new List<double>());
            foreach (var numberExperiments in listNumberExperiments)
            {
                result[i].Add(CalcIntegral.CalculateIntegral(a, b, func, numberExperiments));
            }
        }

        return result;
    }

    private static List<List<double>> InitSeriesCalculatePi(double x0, double y0, double r0,
        int numberCalculationSeries,
        List<int> listNumberExperiments)
    {
        var result = new List<List<double>>();
        for (int i = 0; i < numberCalculationSeries; i++)
        {
            result.Add(new List<double>());
            foreach (var numberExperiments in listNumberExperiments)
            {
                result[i].Add(CalcPi.CalculatePi(x0, y0, r0, numberExperiments));
            }
        }

        return result;
    }


    private static List<List<double>> InitCalculateCalculationEps(List<List<double>> seriesCalculatePi) =>
        seriesCalculatePi
            .Select(seriesResults => seriesResults.Select(item => Math.Abs(item - Math.PI) / Math.PI).ToList())
            .ToList();


    private static double SumCalculationAllSeriesToIndex(List<List<double>> seriesCalculatePi, int index) =>
        seriesCalculatePi.Sum(seriesResult => seriesResult[index]);

    private static List<double> InitListAverageResults(int countListNumberExperiments,
        List<List<double>> seriesCalculatePi)
    {
        var result = new List<double>();
        for (int i = 0; i < countListNumberExperiments; i++)
        {
            result.Add(SumCalculationAllSeriesToIndex(seriesCalculatePi, i) / seriesCalculatePi.Count);
        }

        return result;
    }

    private static List<double> InitListEpsAverageResults(List<double> listAverageResults)
    {
        var result = new List<double>();
        foreach (var averageResult in listAverageResults)
        {
            result.Add(Math.Abs((averageResult - Math.PI) / Math.PI));
        }

        return result;
    }
}