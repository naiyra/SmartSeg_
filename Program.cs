using SmartSeg.Core;
using SmartSeg.DataHandling;
using SmartSeg.FeaturesHandling;
using SmartSeg.MachineLearning;
using SmartSeg.Reporting;

public class MainClass
{
    public static void Main(string[] args)
    {
        string path = "C:\\Users\\naiyr\\source\\repos\\SmartSeg\\Data\\Mall_Customers.csv";
        IDataFrame rawData = CsvLoader.LoadCsv(path);

        var pipeline = new SmartSegPipeline(
            new DataCleaner(),
            new FeatureEngineer(),
            new Clusterer(),
            new SegmentInterpreter()
        );

        pipeline.Run(rawData);
    }
}