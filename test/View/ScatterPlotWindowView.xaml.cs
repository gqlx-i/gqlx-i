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

namespace test.View
{
    /// <summary>
    /// ScatterPlotWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class ScatterPlotWindowView : Window
    {
        private double xLength;
        private double yLength;
        private double xInterval = 10;
        private double yInterval = 10;
        private double upLimit;
        private double lowLimit;
        private double midLine;
        public ScatterPlotWindowView()
        {
            InitializeComponent();
            this.DataContext = Base.GetInstance().ScatterPlotWindowViewModel;
            xLength = ScatterPointCanvas.Width;
            yLength = ScatterPointCanvas.Height;
            upLimit = Base.GetInstance().ScatterPlotWindowViewModel.UpLimit;
            lowLimit = Base.GetInstance().ScatterPlotWindowViewModel.LowLimit;
            midLine = Base.GetInstance().ScatterPlotWindowViewModel.MidLine;
            DrawScatterPointMap();
            DrawScatterPointLabel();

            DrawXMap();
            DrawXLabel();
        }
        #region ScatterPlotCanvas
        private void DrawScatterPointMap()
        {
            Line linex = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            linex.X1 = 0;
            linex.Y1 = yLength;
            linex.X2 = xLength;
            linex.Y2 = yLength;
            ScatterPointCanvas.Children.Add(linex);
            Line liney = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            liney.X1 = 0;
            liney.Y1 = 0;
            liney.X2 = 0;
            liney.Y2 = yLength;
            ScatterPointCanvas.Children.Add(liney);

            TextBlock xblock = new TextBlock()
            {
                Text = "X",
                FontSize = 10,
            };
            Canvas.SetLeft(xblock, xLength / 2);
            Canvas.SetTop(xblock, yLength + 30);
            ScatterPointCanvas.Children.Add(xblock);
            TextBlock yblock = new TextBlock()
            {
                Text = "Y",
                FontSize = 10,
                LayoutTransform = new RotateTransform()
                {
                    Angle = 270,
                },
            };
            Canvas.SetLeft(yblock, -40);
            Canvas.SetTop(yblock, yLength / 2);
            ScatterPointCanvas.Children.Add(yblock);
        }
        private void DrawScatterPointLabel()
        {
            double radius = upLimit - lowLimit;
            double xmid = xLength / 2;
            double ymid = yLength / 2;
            //刻度 中线
            Line liney = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            liney.X1 = -10;
            liney.Y1 = ymid - midLine * yInterval;
            liney.X2 = xLength;
            liney.Y2 = ymid - midLine * yInterval;
            ScatterPointCanvas.Children.Add(liney);
            TextBlock yblock = new TextBlock()
            {
                Text = midLine.ToString(),
                FontSize = 10,
            };
            Canvas.SetLeft(yblock, -20);
            Canvas.SetTop(yblock, liney.Y1);
            ScatterPointCanvas.Children.Add(yblock);
            Line linex = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            linex.X1 = xmid + midLine * xInterval;
            linex.Y1 = 0;
            linex.X2 = xmid + midLine * xInterval;
            linex.Y2 = yLength + 10;
            ScatterPointCanvas.Children.Add(linex);
            TextBlock xblock = new TextBlock()
            {
                Text = midLine.ToString(),
                FontSize = 10,
            };
            Canvas.SetLeft(xblock, linex.X1);
            Canvas.SetTop(xblock, yLength + 20);
            ScatterPointCanvas.Children.Add(xblock);

            //uplimit
            liney = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            liney.X1 = -10;
            liney.Y1 = ymid - upLimit * yInterval - midLine * yInterval;
            liney.X2 = 0;
            liney.Y2 = ymid - upLimit * yInterval - midLine * yInterval;
            ScatterPointCanvas.Children.Add(liney);
            yblock = new TextBlock()
            {
                Text = (upLimit + midLine).ToString(),
                FontSize = 10,
            };
            Canvas.SetLeft(yblock, -20);
            Canvas.SetTop(yblock, liney.Y1);
            ScatterPointCanvas.Children.Add(yblock);
            linex = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            linex.X1 = xmid + upLimit * xInterval + midLine * xInterval;
            linex.Y1 = yLength;
            linex.X2 = xmid + upLimit * xInterval + midLine * xInterval;
            linex.Y2 = yLength + 10;
            ScatterPointCanvas.Children.Add(linex);
            xblock = new TextBlock()
            {
                Text = (upLimit + midLine).ToString(),
                FontSize = 10,
            };
            Canvas.SetLeft(xblock, linex.X1);
            Canvas.SetTop(xblock, yLength + 20);
            ScatterPointCanvas.Children.Add(xblock);

            //lowlimit
            liney = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            liney.X1 = -10;
            liney.Y1 = ymid - lowLimit * yInterval - midLine * yInterval;
            liney.X2 = 0;
            liney.Y2 = ymid - lowLimit * yInterval - midLine * yInterval;
            ScatterPointCanvas.Children.Add(liney);
            yblock = new TextBlock()
            {
                Text = (lowLimit + midLine).ToString(),
                FontSize = 10,
            };
            Canvas.SetLeft(yblock, -20);
            Canvas.SetTop(yblock, liney.Y1);
            ScatterPointCanvas.Children.Add(yblock);
            linex = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            linex.X1 = xmid + lowLimit * xInterval + midLine * xInterval;
            linex.Y1 = yLength;
            linex.X2 = xmid + lowLimit * xInterval + midLine * xInterval;
            linex.Y2 = yLength + 10;
            ScatterPointCanvas.Children.Add(linex);
            xblock = new TextBlock()
            {
                Text = (lowLimit + midLine).ToString(),
                FontSize = 10,
            };
            Canvas.SetLeft(xblock, linex.X1);
            Canvas.SetTop(xblock, yLength + 20);
            ScatterPointCanvas.Children.Add(xblock);

            //范围
            Ellipse circle = new Ellipse()
            {
                Stroke = new SolidColorBrush(Colors.Blue),
                StrokeThickness = 2,
            };
            circle.Width = radius * xInterval;
            circle.Height = radius * yInterval;
            Canvas.SetLeft(circle, (xLength - radius * xInterval) / 2 + midLine * xInterval);
            Canvas.SetTop(circle, (yLength - radius * yInterval) / 2 - midLine * yInterval);
            ScatterPointCanvas.Children.Add(circle);
        }
        private void ScatterPlotCanvasClick(object sender, MouseButtonEventArgs e)
        {
            ScatterPointCanvas.Children.Clear();
            upLimit = Base.GetInstance().ScatterPlotWindowViewModel.UpLimit;
            lowLimit = Base.GetInstance().ScatterPlotWindowViewModel.LowLimit;
            midLine = Base.GetInstance().ScatterPlotWindowViewModel.MidLine;
            DrawScatterPointMap();
            DrawScatterPointLabel();
        }
        #endregion
        #region XCanvas
        private void DrawXMap()
        {
            Line linex = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            linex.X1 = 0;
            linex.Y1 = XCanvas.Height;
            linex.X2 = XCanvas.Width;
            linex.Y2 = XCanvas.Height;
            XCanvas.Children.Add(linex);
            Line liney = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            liney.X1 = 0;
            liney.Y1 = 0;
            liney.X2 = 0;
            liney.Y2 = XCanvas.Height;
            XCanvas.Children.Add(liney);
            liney = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            liney.X1 = XCanvas.Width;
            liney.Y1 = 0;
            liney.X2 = XCanvas.Width;
            liney.Y2 = XCanvas.Height;
            XCanvas.Children.Add(liney);
        }
        private void DrawXLabel()
        {
            double pixline = 0;
            for (int i = 0; pixline <= XCanvas.Width; i++)
            {
                Line linex = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1
                };
                linex.X1 = pixline;
                linex.Y1 = XCanvas.Height;
                linex.X2 = pixline;
                linex.Y2 = XCanvas.Height + 5;
                XCanvas.Children.Add(linex);
                TextBlock xblock = new TextBlock()
                {
                    Text = ((-150 + pixline) / xInterval).ToString(),
                    FontSize = 10,
                };
                xblock.LayoutTransform = new RotateTransform()
                {
                    Angle = 90,
                };
                Canvas.SetLeft(xblock, pixline - 5);
                Canvas.SetTop(xblock, XCanvas.Height + 10);
                XCanvas.Children.Add(xblock);
                pixline = (i + 1) * xInterval;
            }
            pixline = 0;
            for (int j = 0; pixline <= XCanvas.Height; j++)
            {
                Line liney = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1
                };
                liney.X1 = -5;
                liney.Y1 = XCanvas.Height - pixline;
                liney.X2 = 0;
                liney.Y2 = XCanvas.Height - pixline;
                XCanvas.Children.Add(liney);
                TextBlock yblock = new TextBlock()
                {
                    Text = pixline.ToString(),
                    FontSize = 10,
                };
                Canvas.SetLeft(yblock, -30);
                Canvas.SetTop(yblock, XCanvas.Height - pixline);
                XCanvas.Children.Add(yblock);
                pixline = (j + 1) * yInterval;
            }
            pixline = 0;
            for (int j = 0; pixline <= XCanvas.Height; j++)
            {
                Line liney = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1
                };
                liney.X1 = XCanvas.Width;
                liney.Y1 = XCanvas.Height - pixline;
                liney.X2 = XCanvas.Width + 5;
                liney.Y2 = XCanvas.Height - pixline;
                XCanvas.Children.Add(liney);
                TextBlock yblock = new TextBlock()
                {
                    Text = Math.Round(pixline * 0.2 / XCanvas.Height, 3).ToString(),
                    FontSize = 10,
                };
                Canvas.SetLeft(yblock, XCanvas.Width + 5);
                Canvas.SetTop(yblock, XCanvas.Height - pixline);
                XCanvas.Children.Add(yblock);
                pixline = (j + 1) * yInterval;
            }
        }
        private void XCanvasClick(object sender, MouseButtonEventArgs e)
        {
            XCanvas.Children.Clear();
            DrawXMap();
            DrawXLabel();
        }
        #endregion
        #region YCanvas
        private void DrawYMap()
        {
            Line linex = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            linex.X1 = 0;
            linex.Y1 = YCanvas.Height;
            linex.X2 = YCanvas.Width;
            linex.Y2 = YCanvas.Height;
            YCanvas.Children.Add(linex);
            Line liney = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            liney.X1 = 0;
            liney.Y1 = 0;
            liney.X2 = 0;
            liney.Y2 = YCanvas.Height;
            YCanvas.Children.Add(liney);
            liney = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2
            };
            liney.X1 = YCanvas.Width;
            liney.Y1 = 0;
            liney.X2 = YCanvas.Width;
            liney.Y2 = YCanvas.Height;
            YCanvas.Children.Add(liney);
        }
        private void DrawYLabel()
        {
            double pixline = 0;
            for (int i = 0; pixline <= YCanvas.Width; i++)
            {
                Line linex = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1
                };
                linex.X1 = pixline;
                linex.Y1 = YCanvas.Height;
                linex.X2 = pixline;
                linex.Y2 = YCanvas.Height + 5;
                YCanvas.Children.Add(linex);
                TextBlock xblock = new TextBlock()
                {
                    Text = ((-150 + pixline) / xInterval).ToString(),
                    FontSize = 10,
                };
                xblock.LayoutTransform = new RotateTransform()
                {
                    Angle = 90,
                };
                Canvas.SetLeft(xblock, pixline - 5);
                Canvas.SetTop(xblock, YCanvas.Height + 10);
                YCanvas.Children.Add(xblock);
                pixline = (i + 1) * xInterval;
            }
            pixline = 0;
            for (int j = 0; pixline <= YCanvas.Height; j++)
            {
                Line liney = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1
                };
                liney.X1 = -5;
                liney.Y1 = YCanvas.Height - pixline;
                liney.X2 = 0;
                liney.Y2 = YCanvas.Height - pixline;
                YCanvas.Children.Add(liney);
                TextBlock yblock = new TextBlock()
                {
                    Text = pixline.ToString(),
                    FontSize = 10,
                };
                Canvas.SetLeft(yblock, -30);
                Canvas.SetTop(yblock, YCanvas.Height - pixline);
                YCanvas.Children.Add(yblock);
                pixline = (j + 1) * yInterval;
            }
            pixline = 0;
            for (int j = 0; pixline <= YCanvas.Height; j++)
            {
                Line liney = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1
                };
                liney.X1 = YCanvas.Width;
                liney.Y1 = YCanvas.Height - pixline;
                liney.X2 = YCanvas.Width + 5;
                liney.Y2 = YCanvas.Height - pixline;
                YCanvas.Children.Add(liney);
                TextBlock yblock = new TextBlock()
                {
                    Text = Math.Round(pixline * 0.2 / YCanvas.Height, 3).ToString(),
                    FontSize = 10,
                };
                Canvas.SetLeft(yblock, YCanvas.Width + 5);
                Canvas.SetTop(yblock, YCanvas.Height - pixline);
                YCanvas.Children.Add(yblock);
                pixline = (j + 1) * yInterval;
            }
        }
        private void YCanvasClick(object sender, MouseButtonEventArgs e)
        {
            YCanvas.Children.Clear();
            DrawYMap();
            DrawYLabel();
        }
        #endregion

    }
}
