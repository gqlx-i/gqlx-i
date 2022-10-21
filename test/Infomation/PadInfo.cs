using System;
using System.Collections.Generic;
using System.Text;

namespace test.Infomation
{
    public class PadInfo
    {
        public int GlassRow { get; set; } = 0;
        public int GlassColumn { get; set; } = 0;
        public int WaferRow { get; set; } = 0;
        public int WaferColumn { get; set; } = 0;
        public DateTime BuildTime { get; set; } = DateTime.Now;
        public double OffsetX { get; set; } = -0.1;
        public double OffsetY { get; set; } = -0.2;
        public double PEX11 { get; set; } = -0.3;
        public double PEY11 { get; set; } = -0.4;
        public double PEX12 { get; set; } = -0.5;
        public double PEY12 { get; set; } = -0.6;
        public double PEX21 { get; set; } = -0.8;
        public double PEY21 { get; set; } = -1;
        public double PEX22 { get; set; } = 0.2;
        public double PEY22 { get; set; } = 0;
        public double MoveX1 { get; set; } = 0.4;
        public double MoveY1 { get; set; } = 0.6;
        public double MoveX2 { get; set; } = 0.8;
        public double MoveY2 { get; set; } = 1;
    }
}
