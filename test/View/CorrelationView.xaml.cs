using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using test.Infomation;
using test.ViewModel;

namespace test.View
{
    /// <summary>
    /// CorrelationView.xaml 的交互逻辑
    /// </summary>
    public partial class CorrelationView : Window
    {
        private double yScale = 0.2;
        private double xInterval = 1;
        private double yInterval = 0.2;
        private List<string> _xLabelList;
        private List<string> _xLabelTempList;
        private List<string> _yLabelList = new List<string>() { "1", "0.6", "0.2", "-0.2", "-0.6", "-1" };
        private string temp = "";
        public CorrelationView()
        {
            InitializeComponent();
            this.DataContext = Base.GetInstance().CorrelationViewModel;
            _xLabelList = Base.GetInstance().CorrelationViewModel.XLabelList;
            InitalXLabelTempList();
            xInterval = (int)CorrelationCanvas.Width / _xLabelList.Count;
            yInterval = (int)CorrelationCanvas.Height / (2 * _yLabelList.Count);
            DrawCorrelationMap();
            DrawCorrelationMapLabel();
            DrawCorrelationMapValue();
        }
        //初始化X坐标临时集合
        private void InitalXLabelTempList()
        {
            _xLabelTempList = new List<string>();
            foreach (var xlabel in _xLabelList)
            {
                _xLabelTempList.Add(xlabel);
            }
        }
        //Combobox选项改变
        private void XLabelChanged(object sender, SelectionChangedEventArgs e)
        {
            CorrelationCanvas.Children.Clear();
            DrawCorrelationMap();
            DrawCorrelationMapLabel();
            DrawCorrelationMapValue();
        }
        //坐标系绘制
        private void DrawCorrelationMap()
        {
            for (int i = 0; i < _xLabelList.Count + 1; ++i)
            {
                Line lineX = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1,
                };
                lineX.X1 = i * xInterval + 10;
                lineX.X2 = i * xInterval + 10;
                lineX.Y1 = yInterval;
                lineX.Y2 = _yLabelList.Count * yInterval * 2 - yInterval + 10;
                CorrelationCanvas.Children.Add(lineX);
            }
            for (int j = 0; j < 2 * _yLabelList.Count - 1; ++j)
            {
                Line lineY = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1,
                };
                lineY.X1 = 0;
                lineY.X2 = _xLabelList.Count * xInterval + 10;
                lineY.Y1 = (j + 1) * yInterval;
                lineY.Y2 = (j + 1) * yInterval;
                CorrelationCanvas.Children.Add(lineY);
            }
        }
        //坐标标签绘制
        private void DrawCorrelationMapLabel()
        {
            temp = Base.GetInstance().CorrelationViewModel.SelectedXLabel;
            _xLabelTempList.Remove(temp);
            for (int i = 0; i < _xLabelTempList.Count; i++)
            {
                TextBlock xblock = new TextBlock();
                xblock.Foreground = new SolidColorBrush(Colors.Black);
                xblock.FontSize = 10;
                xblock.Text = _xLabelTempList[i];
                xblock.LayoutTransform = new RotateTransform()
                {
                    Angle = 60,
                };
                Canvas.SetLeft(xblock, (i + 1) * xInterval);
                Canvas.SetTop(xblock, CorrelationCanvas.Height);
                CorrelationCanvas.Children.Add(xblock);
            }
            for (int j = 0; j < _yLabelList.Count; j++)
            {
                TextBlock yblock = new TextBlock();
                yblock.Foreground = new SolidColorBrush(Colors.Black);
                yblock.FontSize = 10;
                yblock.Text = _yLabelList[j];
                Canvas.SetLeft(yblock, -30);
                Canvas.SetTop(yblock, j * 2 * yInterval + 16);
                CorrelationCanvas.Children.Add(yblock);
            }
        }
        //数值绘制
        private void DrawCorrelationMapValue()
        {
            double zeroLine;
            PadInfo padInfo = new PadInfo();
            for (int i = 0; i < _xLabelTempList.Count; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Stroke = new SolidColorBrush(Colors.Black);
                rect.StrokeThickness = 1;
                rect.Fill = new SolidColorBrush(Colors.Blue);
                double val = GetXLabelValue(padInfo, i) / yScale * yInterval;
                rect.Height = Math.Abs(val);
                rect.Width = xInterval / 2;
                zeroLine = CorrelationCanvas.Height / 2;
                if (val < 0)
                {
                    zeroLine = CorrelationCanvas.Height / 2 - rect.Height;
                }
                Canvas.SetLeft(rect, (i + 1) * xInterval);
                Canvas.SetTop(rect, zeroLine);
                CorrelationCanvas.Children.Add(rect);
            }
            InitalXLabelTempList();
        }
        private double GetXLabelValue(PadInfo padInfo, int index)
        {
            double val = 0;
            switch (_xLabelTempList[index])
            {
                case "OffsetX": val = padInfo.OffsetX; break;
                case "OffsetY": val = padInfo.OffsetY; break;
                case "PEX11": val = padInfo.PEX11; break;
                case "PEY11": val = padInfo.PEY11; break;
                case "PEX12": val = padInfo.PEX12; break;
                case "PEY12": val = padInfo.PEY12; break;
                case "PEX21": val = padInfo.PEX21; break;
                case "PEY21": val = padInfo.PEY21; break;
                case "PEX22": val = padInfo.PEX22; break;
                case "PEY22": val = padInfo.PEY22; break;
                case "MoveX1": val = padInfo.MoveX1; break;
                case "MoveY1": val = padInfo.MoveY1; break;
                case "MoveX2": val = padInfo.MoveX2; break;
                case "MoveY2": val = padInfo.MoveY2; break;
                default: break;
            }
            return val;
        }
    }
}
