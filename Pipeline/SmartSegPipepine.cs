using SmartSeg.Core;
using SmartSeg.DataHandling;
using SmartSeg.FeaturesHandling;
using SmartSeg.MachineLearning;
using SmartSeg.Reporting;

public class SmartSegPipeline
{
    private readonly IDataCleaner cleaner;
    private readonly IFeatureEngineer engineer;
    private readonly IClusterer clusterer;
   private readonly ISegmentInterpreter interpreter;

    public SmartSegPipeline(IDataCleaner cleaner, IFeatureEngineer engineer, IClusterer clusterer, ISegmentInterpreter interpreter)
    {
        this.cleaner = cleaner;
        this.engineer = engineer;
       this.clusterer = clusterer;
       this.interpreter = interpreter;
    }

    public void Run(IDataFrame rawData)
    {
        var cleaned = cleaner.Clean(rawData);
        var features = engineer.Transform(cleaned);
        //var clustered = clusterer.Cluster(features);
        // var segments = interpreter.Interpret(clustered);

        /* foreach (var segment in segments)
         {
             Console.WriteLine($"Cluster {segment.ClusterId}: {segment.Description}");
             foreach (var stat in segment.Stats)
                 Console.WriteLine($"  {stat.Key}: {stat.Value}");
         }*/
    }
}
