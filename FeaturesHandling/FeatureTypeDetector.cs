using SmartSeg.Core;
namespace SmartSeg.FeatureHandling
{
    
    public class FeatureTypeDetector
    {
        public (List<string> numericCols, List<string> categoricalCols) Detect(IDataFrame df)
        {
            var numeric = new List<string>();
            var categorical = new List<string>();

            foreach (var col in df.GetColumnNames())
            {
                var values = df.GetColumnValues(col)
                               .Where(v => v != null)
                               .Select(v => v.ToString()); //converts all non null values to strings

                if (values.All(v => double.TryParse(v, out _)))
                {
                    var uniqueCount = values.Distinct().Count();
                    if (uniqueCount < 0.05 * df.RowCount)
                        categorical.Add(col);
                    else
                        numeric.Add(col);
                }
                else
                {
                    categorical.Add(col);
                }
            }

            return (numeric, categorical);
        }
    }
}
