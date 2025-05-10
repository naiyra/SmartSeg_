
using SmartSeg.Core;
namespace SmartSeg.FeatureHandling
{
    public class LabelEncoder
    {
        private readonly Dictionary<string, Dictionary<string, int>> encoders = new();

        public IDataFrame Encode(IDataFrame df, List<string> categoricalCols)
        {
            foreach (var col in categoricalCols)
            {
                //var values = df.GetColumnValues(col).Select(v => v?.ToString()).ToList();
                //var unique = values.Distinct().ToList();

                //var map = unique.Select((val, idx) => new { val, idx })
                // .ToDictionary(x => x.val, x => x.idx);
                var values = df.GetColumnValues(col)
               .Select(v => v?.ToString() ?? "UNKNOWN") 
               .ToList();

                var unique = values.Distinct().ToList();

                var map = unique.Select((val, idx) => new { val, idx })
                                .ToDictionary(x => x.val, x => x.idx); 


                encoders[col] = map;

                var encoded = values.Select(v => (object)map[v]).ToList();
                df.SetColumnValues(col, encoded);
            }

            return df;
        }
    }
}
