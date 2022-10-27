using System;
using System.Collections.Generic;
using System.Text;
using test.Resources;

namespace test.Infomation
{
    public class PadInfo
    {
        public PadInfo()
        {
            Random rd = new Random();
            OffsetX = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            OffsetY = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            PEX11 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            PEY11 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            PEX12 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            PEY12 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            PEX21 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            PEY21 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            PEX22 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            PEY22 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            MoveX1 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            MoveY1 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            MoveX2 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
            MoveY2 = Math.Round(rd.NextDouble() * Math.Pow(-1, rd.Next(-1, 1)), 2);
        }
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
    public class PadAndInfo
    {
        public MyCircle MyCircle { get; set; }
        public MyRectangle MyRectangle { get; set; }
        public PadInfo PadInfo { get; set; }
    }
}
