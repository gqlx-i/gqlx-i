using System;
using System.Collections.Generic;
using System.Text;

namespace test.ViewModel
{
    public class ScatterPlotWindowViewModel
    {
        public double UpLimit { get; set; } = 15;
        public double LowLimit { get; set; } = -15;
        public double MidLine { get; set; }
    }
}
