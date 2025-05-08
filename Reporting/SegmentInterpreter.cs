using SmartSeg.MachineLearning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSeg.Reporting
{
    public class SegmentInterpreter : ISegmentInterpreter
    {
        public List<SegmentSummary> Interpret(ClusteredResult clusteredData)
        {
            // Compute average age, income, dominant categories etc. per cluster
            return new List<SegmentSummary>(); // placeholder
        }
    }
}
