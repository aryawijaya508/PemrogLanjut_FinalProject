using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator_2.Model
{
    public class LiveCurrInfo
    {
        public string _base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }
        public bool success { get; set; }
        public int timestamp { get; set; }
    }

    public class Rates
    {
        public double IDR { get; set; }
        public double USD { get; set; }
        public double EUR { get; set; }
        public double MYR { get; set; }
        public double JPY { get; set; }
    }

}
