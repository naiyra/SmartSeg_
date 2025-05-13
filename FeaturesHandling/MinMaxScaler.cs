using SmartSeg.Core;
namespace SmartSeg.FeatureHandling
{
    

    public class MinMaxScaler
    {
        public IDataFrame Scale(IDataFrame df, List<string> numericCols)
        {
            foreach (var col in numericCols)
            {
                var values = df.GetColumnValues(col)
                               .Select(v => Convert.ToDouble(v))
                               .ToList();

                double min = values.Min();
                double max = values.Max();

                List<object> scaled;

                if (Math.Abs(max - min) < 1e-9)
                {
                    scaled = values.Select(v => (object)0.0).ToList();
                }
                else
                {
                    scaled = values.Select(v => (object)((v - min) / (max - min))).ToList();
                }

                df.SetColumnValues(col, scaled);
            }

            return df;
        }
    }
}
