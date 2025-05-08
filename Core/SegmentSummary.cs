using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSeg.Core
{
    public class SegmentSummary
    {
        public int ClusterId { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Stats { get; set; }
    }
}
