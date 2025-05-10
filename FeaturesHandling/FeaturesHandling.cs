using SmartSeg.Core;
using SmartSeg.FeatureHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSeg.FeaturesHandling
{
    public class FeaturesHandling : IFeaturesHandling
    {
        private readonly FeatureTypeDetector detector = new();
        private readonly LabelEncoder encoder = new();
        private readonly MinMaxScaler scaler = new();

        public IDataFrame Transform(IDataFrame input)
        {
            var df = input.Clone();
            var (num, cat) = detector.Detect(df);
            df = encoder.Encode(df, cat);
            df = scaler.Scale(df, num);
            return df;
        }
    }

}
