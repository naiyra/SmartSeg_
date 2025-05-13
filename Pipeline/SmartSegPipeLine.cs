using SmartSeg.Core;
using SmartSeg.DataHandling;
using SmartSeg.FeaturesHandling;
using SmartSeg.MachineLearning;
using SmartSeg.Reporting;
using System;
using System.Collections.Generic;
using System.Threading;

public class SmartSegPipeline
{
    private readonly IDataCleaner cleaner;
    private readonly IFeaturesHandling featureHandling;
    private readonly IClusterer clusterer;
    private readonly ISegmentInterpreter interpreter;

    public SmartSegPipeline(IDataCleaner cleaner, IFeaturesHandling featureHandling, IClusterer clusterer, ISegmentInterpreter interpreter)
    {
        this.cleaner = cleaner;
        this.featureHandling = featureHandling;
        this.clusterer = clusterer;
        this.interpreter = interpreter;
    }

    /// <summary>
    /// Runs the full SmartSeg process: Cleaning → Feature Engineering → Clustering → Interpreting
    /// Shows a spinner while running, then returns the list of segment summaries.
    /// </summary>
    public List<SegmentSummary> RunAndReturnSegments(IDataFrame rawData)
    {
        // Start spinner in background
        var spinnerThread = new Thread(() => ShowSpinner("Running SmartSeg pipeline..."));
        spinnerThread.Start();

        try
        {
            // Slight delay to let spinner show nicely
            Thread.Sleep(300);

            // Core processing steps
            var cleaned = cleaner.Clean(rawData);
            var features = featureHandling.Transform(cleaned);
            var clustered = clusterer.Cluster(features);
            var segments = interpreter.Interpret(clustered);

            return segments;
        }
        finally
        {
            // Always stop spinner
            spinnerThread.Interrupt();
            Console.WriteLine("\nProcessing completed!");
        }
    }

    /// <summary>
    /// Simple spinner animation displayed while the main processing runs.
    /// </summary>
    private void ShowSpinner(string message)
    {
        char[] sequence = new char[] { '|', '/', '-', '\\' };
        int counter = 0;

        try
        {
            while (true)
            {
                Console.Write($"\r[{sequence[counter]}] {message}");
                counter++;
                if (counter >= sequence.Length) counter = 0;
                Thread.Sleep(100);
            }
        }
        catch (ThreadInterruptedException)
        {
            // Spinner stopped cleanly when interrupted
        }
    }
}
