using SmartSeg.Core;
using SmartSeg.DataHandling;
using SmartSeg.FeaturesHandling;
using SmartSeg.MachineLearning;
using SmartSeg.Reporting;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

public class SmartSegPipeline
{
    private readonly IDataCleaner cleaner;
    private readonly IFeaturesHandling handling;
    private readonly IClusterer clusterer;
   private readonly ISegmentInterpreter interpreter;
    private DataCleaner dataCleaner;
    private FeaturesHandling featuresHandling;
    private SegmentInterpreter segmentInterpreter;

    /*public SmartSegPipeline(IDataCleaner cleaner, IFeaturesHandling handling, IClusterer clusterer, ISegmentInterpreter interpreter)
    {
        this.cleaner = cleaner;
        this.handling = handling;
       this.clusterer = clusterer;
       this.interpreter = interpreter;
    }
    */
    public SmartSegPipeline(DataCleaner dataCleaner, FeaturesHandling featuresHandling, Clusterer clusterer, SegmentInterpreter segmentInterpreter)
    {
        this.dataCleaner = dataCleaner;
        this.featuresHandling = featuresHandling;
        this.clusterer = clusterer;
        this.segmentInterpreter = segmentInterpreter;
    }

    public void Run(IDataFrame rawData)
    {
        // var cleaned = cleaner.Clean(rawData);
        //var features = handling.Transform(cleaned);
        //var clustered = clusterer.Cluster(features);
        // var segments = interpreter.Interpret(clustered);

        /*foreach (var segment in segments)
        {
            Console.WriteLine($"Cluster {segment.ClusterId}: {segment.Description}");
            foreach (var stat in segment.Stats)
                Console.WriteLine($"  {stat.Key}: {stat.Value}");
        }*/

      /*  Cluster 1: Young Low-Income Customers
            Average Age: 25
            Average Income: 4000

          Cluster 2: Mature High-Income Customers
            Average Age: 45
            Average Income: 12000
      */

    }
}
