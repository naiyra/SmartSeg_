using SmartSeg.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSeg.FeaturesHandling
{
    public class FeatureEngineer : IFeatureEngineer
    {
        public IDataFrame Transform(IDataFrame cleanedInput)
        {
            // Apply label encoding, normalization
            // Output all-numeric feature matrix
            return cleanedInput; // placeholder
        }
    }
}
