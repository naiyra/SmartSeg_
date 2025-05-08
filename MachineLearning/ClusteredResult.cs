using SmartSeg.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSeg.MachineLearning
{
    public class ClusteredResult
    {
        public IDataFrame OriginalWithLabels { get; set; }
        public int OptimalK { get; set; }
        public Dictionary<int, List<int>> ClusterAssignments { get; set; }
    }
}
