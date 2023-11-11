namespace Practice1;

internal abstract class Program
{
    static void Main(string[] args)
    {
        double x0 = 1;
        double y0 = 2;
        double r0 = 5;
        int numberCalculationSeries = 5;
        List<int> listNumberExperiments = new List<int>()
        {
            (int)Math.Pow(10, 4),
            (int)Math.Pow(10, 5),
            (int)Math.Pow(10, 6),
            (int)Math.Pow(10, 7),
            (int)Math.Pow(10, 8)
        };
        var seriesCalculatePi =
            InitSeriesCalculatePi(x0, y0, r0, numberCalculationSeries, listNumberExperiments);
        var listEpsSeriesResults = InitCalculateCalculationEps(seriesCalculatePi);
        var listAverageResults = InitListAverageResults(listNumberExperiments.Count, seriesCalculatePi);
        var listEpsAverageResults = InitListEpsAverageResults(listAverageResults);
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
                Console.WriteLine("CalculatePi output:" + result[i].Last());
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