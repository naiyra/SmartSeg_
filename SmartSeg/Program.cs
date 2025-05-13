using SmartSeg.Core;
using SmartSeg.DataHandling;
using SmartSeg.FeaturesHandling;
using SmartSeg.MachineLearning;
using SmartSeg.Reporting;

public class Program
{
    private static IDataFrame rawData;
    private static SmartSegPipeline pipeline;
    private static List<SegmentSummary> segments;
    private static ConsoleUIManager ui = new ConsoleUIManager();

    public static void Main(string[] args)
    {
        InitializePipeline();

        bool exit = false;

        while (!exit)
        {
            ui.ShowWelcomeMessage();
            ui.ShowMenu();
            var input = ui.GetUserInput();

            switch (input)
            {
                case "1":
                    LoadDataset();
                    break;
                case "2":
                    RunSegmentation();
                    break;
                case "3":
                    ShowSegments();
                    break;
                case "4":
                    SaveSegments();
                    break;
                case "5":
                    TestFeatureHandling();  // ✨ new case
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    ui.ShowMessage("Invalid choice. Try again.", isError: true);
                    ui.WaitForUser();
                    break;
            }


        }
    }

    private static void InitializePipeline()
    {
        IDataCleaner cleaner = new DataCleaner();
        IFeaturesHandling featuresHandling = new FeaturesHandling();
        IClusterer clusterer = new Clusterer();
        ISegmentInterpreter interpreter = new SegmentInterpreter();
        pipeline = new SmartSegPipeline(cleaner, featuresHandling, clusterer, interpreter);
    }

    private static void LoadDataset()
    {
        string path = ui.AskForDatasetPath();

        try
        {
            rawData = CsvLoader.LoadCsv(path);
            ui.ShowMessage("Dataset loaded successfully!");
        }
        catch (Exception ex)
        {
            ui.ShowMessage($"Error loading dataset: {ex.Message}", isError: true);
        }

        ui.WaitForUser();
    }

    private static void RunSegmentation()
    {
        if (rawData == null)
        {
            ui.ShowMessage("Please load a dataset first!", isError: true);
            ui.WaitForUser();
            return;
        }

        segments = pipeline.RunAndReturnSegments(rawData);
        ui.ShowMessage("Segmentation completed!");
        ui.WaitForUser();
    }


    private static void ShowSegments()
    {
        ui.ShowSegments(segments);
        ui.WaitForUser();
    }

    private static void SaveSegments()
    {
        ui.SaveSegmentsToFile(segments);
        ui.WaitForUser();
    }



    private static void TestFeatureHandling()
    {
        Console.WriteLine("Enter path to your dataset:");
        string path = Console.ReadLine();

        try
        {
            IDataFrame rawData = CsvLoader.LoadCsv(path);

            Console.WriteLine("Dataset loaded. Running Feature Engineering...");

            FeaturesHandling featuresHandling = new FeaturesHandling();
            var transformedData = featuresHandling.Transform(rawData);

            Console.WriteLine("\n=== Feature Engineering Result ===\n");

            foreach (var column in transformedData.GetColumnNames())
            {
                Console.WriteLine($"Column: {column}");
                var values = transformedData.GetColumnValues(column).Take(5); // show only first 5 values
                Console.WriteLine("Sample Values: " + string.Join(", ", values));
                Console.WriteLine("--------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nTest completed. Press Enter to return...");
        Console.ReadLine();
    }


}
