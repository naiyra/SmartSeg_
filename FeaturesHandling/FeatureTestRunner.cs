
using SmartSeg.Core;
using System.Data;
namespace SmartSeg.FeaturesHandling
{

    public static class FeatureTestRunner
    {
        public static void Run()
        {
            var table = new DataTable();
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("Income", typeof(double));

            table.Rows.Add(25, "Cairo", 5000.0);
            table.Rows.Add(30, "Alex", 7000.0);
            table.Rows.Add(45, "Cairo", 12000.0);
            table.Rows.Add(35, "Luxor", 8000.0);

            IDataFrame df = new SmartDataFrame(table);
            IFeaturesHandling engineer = new FeaturesHandling();
            IDataFrame transformed = engineer.Transform(df);

            foreach (var col in transformed.GetColumnNames())
            {
                Console.WriteLine($"{col}: {string.Join(", ", transformed.GetColumnValues(col))}");
            }
        }
    }
}

