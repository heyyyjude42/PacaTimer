using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacaTimer
{
    public class TimerSegment
    {
        public TimeSpan Duration { get; set; }
        public string Label { get; set; }
        public List<string> SecondaryLabels { get; set; }
    }
}
