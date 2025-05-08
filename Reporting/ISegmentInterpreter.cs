using SmartSeg.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSeg.Reporting
{
    public interface ISegmentInterpreter
    {
        List<SegmentSummary> Interpret(ClusteredResult clusteredData);
    }

}
