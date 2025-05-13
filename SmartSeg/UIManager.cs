using SmartSeg.Core;
using SmartSeg.Reporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public class ConsoleUIManager
{
    public void ShowWelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine("==== Welcome to SmartSeg ====\n");
    }

    public void ShowMenu()
    {
        Console.WriteLine("1. Load Dataset");
        Console.WriteLine("2. Run Segmentation");
        Console.WriteLine("3. Show Segments");
        Console.WriteLine("4. Save Segments to File");
        Console.WriteLine("5. Test Feature Engineering ✨");
        Console.WriteLine("6. Exit\n");
        Console.Write("Select an option: ");
    }


    public string GetUserInput()
    {
        return Console.ReadLine();
    }

    public string AskForDatasetPath()
    {
        Console.Write("Enter the full path to your CSV dataset: ");
        return Console.ReadLine();
    }

    public void ShowMessage(string message, bool isError = false)
    {
        if (isError)
            Console.ForegroundColor = ConsoleColor.Red;
        else
            Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void ShowSegments(List<SegmentSummary> segments)
    {
        if (segments == null || segments.Count == 0)
        {
            ShowMessage("No segments to display.", isError: true);
            return;
        }

        ConsoleColor[] colors = new ConsoleColor[]
        {
            ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Green,
            ConsoleColor.Magenta, ConsoleColor.Blue, ConsoleColor.DarkCyan
        };

        int colorIndex = 0;

        foreach (var segment in segments)
        {
            Console.ForegroundColor = colors[colorIndex % colors.Length];
            Console.WriteLine($"\nCluster {segment.ClusterId}: {segment.Description}");
            foreach (var stat in segment.Stats)
            {
                Console.WriteLine($"  {stat.Key}: {stat.Value}");
            }
            Console.ResetColor();
            colorIndex++;
        }
    }

    public void WaitForUser()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    public void ShowProgress(string message, int durationMilliseconds = 2000)
    {
        char[] sequence = new char[] { '|', '/', '-', '\\' };
        int counter = 0;
        int iterations = durationMilliseconds / 100;

        for (int i = 0; i < iterations; i++)
        {
            Console.Write($"\r[{sequence[counter]}] {message}");
            counter++;
            if (counter >= sequence.Length) counter = 0;
            Thread.Sleep(100);
        }
        Console.WriteLine(); // Move to next line
    }

    public void SaveSegmentsToFile(List<SegmentSummary> segments)
    {
        if (segments == null || segments.Count == 0)
        {
            ShowMessage("No segments available to save.", isError: true);
            return;
        }

        Console.Write("Enter the full path to save the file (including filename.txt): ");
        string savePath = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(savePath))
            {
                foreach (var segment in segments)
                {
                    writer.WriteLine($"Cluster {segment.ClusterId}: {segment.Description}");
                    foreach (var stat in segment.Stats)
                    {
                        writer.WriteLine($"  {stat.Key}: {stat.Value}");
                    }
                    writer.WriteLine(); // Empty line between clusters
                }
            }

            ShowMessage($"Segments saved successfully to {savePath}");
        }
        catch (Exception ex)
        {
            ShowMessage($"Error saving file: {ex.Message}", isError: true);
        }
    }
}
