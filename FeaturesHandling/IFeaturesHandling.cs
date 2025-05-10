using SmartSeg.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSeg.FeaturesHandling
{
    public interface IFeaturesHandling
    {
        IDataFrame Transform(IDataFrame cleanedInput);
    }

   

}
