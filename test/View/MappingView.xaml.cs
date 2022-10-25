using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using test.Infomation;
using test.Resources;
using test.ViewModel;

namespace test.View
{
    /// <summary>
    /// MappingView.xaml 的交互逻辑
    /// </summary>
    public partial class MappingView : UserControl
    {
        private bool isCanMove = false;//鼠标是否移动
        private bool isLeftButtonUp = true;
        private bool isRightButtonUp = true;
        private bool isShiftKeyUp = true;
        private Border currentBoxSelectedBorder = null;//拖动展示的提示框
        private Point tempStartPoint;
        private int yLength = 10;
        private int yInterval = 10;
        private int xLength = 10;
        private int xInterval = 10;
        private int xMaxValue = 0;
        private int yMaxValue = 0;
        private int largePx = 10;
        private int shortPx = 5;
        private double scale = 1;
        private List<PadAndInfo> rectSelectedPadAndInfos = new List<PadAndInfo>();
        
        public MappingView()
        {
            InitializeComponent();
            this.DataContext = Base.GetInstance().MappingViewModel;
            xLength = (int)CanvasInPath.Width;
            yLength = (int)CanvasInPath.Height;
            DrawPadMap(xLength, yLength);
            DrawPadMapLabel(0, 0, xLength, yLength);
            ExampleChanged(xLength, yLength);
        }
        {
            scrollView.PageLeft();
            scrollView.ScrollToLeftEnd();
        }

        public void Restore_Click(object sender,RoutedEventArgs e)
        {
            scrollView.ScrollToTop();
            scrollView.PageUp();
            scrollView.ScrollToLeftEnd();
            scrollView.PageLeft();
        }

        //public static void ScrollViewToVerticalTop(FrameworkElement element,ScrollViewer scrollViewer)
        //{
        //    var scrollViewOffset = scrollViewer.VerticalOffset;
        //    var point = new Point(0, scrollViewOffset);
        //    var tarPos = element.TransformToVisual(scrollViewer).Transform(point);
        //    scrollViewer.ScrollToVerticalOffset(tarPos.Y);
        //}

        //public static void ScrollViewToHorizontalRight(FrameworkElement element, ScrollViewer scrollViewer)
        //{
        //    var scrollViewOffset = scrollViewer.HorizontalOffset;
        //    var point = new Point(scrollViewOffset, 0);
        //    var tarPos = element.TransformToVisual(scrollViewer).Transform(point);
        //    scrollViewer.ScrollToVerticalOffset(tarPos.X);
        //}

        #region 键盘事件监听
        // Shift按下
        private void Window_Keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyStates == Keyboard.GetKeyStates(Key.LeftShift) || e.KeyStates == Keyboard.GetKeyStates(Key.RightShift))
            {
                isShiftKeyUp = false;
                this.CanvasInPath.Cursor = Cursors.Cross;
            }
        }
        // Shift抬起
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyStates == Keyboard.GetKeyStates(Key.LeftShift) || e.KeyStates == Keyboard.GetKeyStates(Key.RightShift))
            {
                isShiftKeyUp = true;
                this.CanvasInPath.Cursor = Cursors.Arrow;
            }
        }
        #endregion
        #region 鼠标事件监听
        /// <summary>
        /// 鼠标按下记录起始点
        /// </summary>
        private void CanvasInPath_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isLeftButtonUp = false;
            isCanMove = true;
            tempStartPoint = e.GetPosition(this.CanvasInPath);
        }
        private void CanvasInPath_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            isRightButtonUp = false;
            scrollView.ScrollToTop();
            scrollView.PageUp();
            scrollView.PageLeft();
            //isCanMove = true;
            //tempStartPoint = e.GetPosition(this.CanvasInPath);
        }
        /// <summary>
        /// 框选逻辑
        /// </summary>
        private void CanvasInPath_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCanMove && isLeftButtonUp == false && isShiftKeyUp == false)
            {
                Point tempEndPoint = e.GetPosition(this.CanvasInPath);
                //绘制跟随鼠标移动的方框
                DrawMultiselectBorder(tempEndPoint, tempStartPoint);
            }
        }
        /// <summary>
        /// 鼠标抬起时清除选框
        /// </summary>
        private void CanvasInPath_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isLeftButtonUp = true;
            //放大子控件
            if (currentBoxSelectedBorder != null)
            {
                //获取选框的矩形位置
                Point tempEndPoint = e.GetPosition(this.CanvasInPath);
                Rect tempRect = new Rect(tempStartPoint, tempEndPoint);
                //获取子控件
                List<ExampleC> childList = GetChildObjects<ExampleC>(this.CanvasInPath);
                foreach (var child in childList)
                {
                    //获取子控件矩形位置
                    Rect childRect = new Rect(Canvas.GetLeft(child), Canvas.GetTop(child), child.Width, child.Height);
                    PadAndInfo padAndInfo = new PadAndInfo();
                    //若子控件与选框相交则改变样式
                    if (childRect.IntersectsWith(tempRect))
                    {
                        padAndInfo.ExampleC = child;
                        padAndInfo.PadInfo = new PadInfo();
                        padAndInfo.PadInfo.GlassColumn = GetPadPosition(child, xInterval);
                        padAndInfo.PadInfo.GlassRow = GetPadPosition(child, yInterval);
                        rectSelectedPadAndInfos.Add(padAndInfo);
                        child.Opacity = 0.4;
                    }                   
                }
                if (rectSelectedPadAndInfos.Count != 0)
                {
                    DrawROI();
                }
                this.CanvasInPath.Children.Remove(currentBoxSelectedBorder);
                currentBoxSelectedBorder = null;
            }
            isCanMove = false;
        }
        #endregion
        /// <summary>
        /// 绘制坐标轴和刻度
        /// </summary>
        private void DrawPadMap(double xLength, double yLength)
        {
            //坐标线
            Line lineY = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 1,
            };
            lineY.X1 = 0;
            lineY.X2 = 0;
            lineY.Y1 = 0;
            lineY.Y2 = yLength;
            CanvasInPath.Children.Add(lineY);
            Line lineX = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 1,
            };
            lineX.X1 = 0;
            lineX.X2 = xLength;
            lineX.Y1 = yLength;
            lineX.Y2 = yLength;
            CanvasInPath.Children.Add(lineX);
            //轴标Y
            TextBlock yAxisLabel = new TextBlock();
            yAxisLabel.Foreground = new SolidColorBrush(Colors.Black);
            yAxisLabel.FontSize = 12;
            yAxisLabel.Text = "column";
            yAxisLabel.LayoutTransform = new RotateTransform()
            {
                Angle = 270,
            };
            Canvas.SetLeft(yAxisLabel, -50);
            Canvas.SetTop(yAxisLabel, yLength / 2);
            CanvasInPath.Children.Add(yAxisLabel);
            //轴标X
            TextBlock xAxisLabel = new TextBlock();
            xAxisLabel.Foreground = new SolidColorBrush(Colors.Black);
            xAxisLabel.FontSize = 12;
            xAxisLabel.Text = "row";
            Canvas.SetLeft(xAxisLabel, xLength / 2);
            Canvas.SetTop(xAxisLabel, yLength + 20);
            CanvasInPath.Children.Add(xAxisLabel);
        }
        private void DrawPadMapLabel(double startX, double startY, double xLength, double yLength)
        {
            double pixLine = 0;
            #region 刻度线
            for (int i = 0; pixLine <= yLength; ++i)
            {
                TextBlock yblock = new TextBlock();
                yblock.Foreground = new SolidColorBrush(Colors.Black);
                yblock.FontSize = 10;
                yblock.Text = i + startY + "";
                Canvas.SetLeft(yblock, -20);
                Canvas.SetTop(yblock, yLength - pixLine - 5);
                CanvasInPath.Children.Add(yblock);
                Line ly = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1,
                };
                ly.X1 = 0;
                ly.X2 = i % 5 == 0 ? largePx : shortPx;
                ly.Y1 = yLength - i * yInterval * scale;
                ly.Y2 = yLength - i * yInterval * scale;
                CanvasInPath.Children.Add(ly);
                pixLine = (i + 1) * yInterval * scale;
            }
            pixLine = 0;
            for (int i = 0; pixLine <= xLength; ++i)
            {
                TextBlock xblock = new TextBlock();
                xblock.Foreground = new SolidColorBrush(Colors.Black);
                xblock.FontSize = 10;
                xblock.Text = i + startX + "";
                Canvas.SetLeft(xblock, pixLine - 5);
                Canvas.SetTop(xblock, yLength + 5);
                CanvasInPath.Children.Add(xblock);
                Line lx = new Line()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1,
                };
                lx.X1 = i * xInterval * scale;
                lx.X2 = i * xInterval * scale;
                lx.Y1 = yLength;
                lx.Y2 = i % 5 == 0 ? yLength - largePx : yLength - shortPx;
                CanvasInPath.Children.Add(lx);
                pixLine = (i + 1) * xInterval * scale;
            }
            #endregion
        }
        private void ScaleChanged(object sender, RoutedEventArgs e)
        {
            if (CanvasInPath != null)
            {
                CanvasInPath.Children.Clear();
                xMaxValue = xLength * (int)ScaleSlider.Value;
                yMaxValue = yLength * (int)ScaleSlider.Value;
                scale = ScaleSlider.Value;
                CanvasInPath.Width = xMaxValue;
                CanvasInPath.Height = yMaxValue;
                DrawPadMap(xMaxValue, yMaxValue);
                DrawPadMapLabel(0, 0, xMaxValue, yMaxValue);
                ExampleChanged(xMaxValue, yMaxValue);
            }
        }
        //图例改变触发事件
        private void ExampleChanged(double xLength, double yLength)
        {
            #region Pad
            Point temp = new Point(0, 0);
            for (int i = 0; temp.X <= xLength; ++i)
            {
                temp.Y = 0;
                List<PadAndInfo> list = new List<PadAndInfo>();
                for (int j = 0; temp.Y <= yLength; ++j)
                {
                    PadAndInfo padAndInfo = new PadAndInfo();
                    PadInfo padInfo = new PadInfo();
                    padInfo.GlassRow = i;
                    padInfo.GlassColumn = j;
                    padAndInfo.PadInfo = padInfo;
                    padAndInfo.ExampleC = new ExampleC();
                    padAndInfo.ExampleC.Height = 5;
                    padAndInfo.ExampleC.Width = 5;
                    padAndInfo.ExampleC.ToolTip = i.ToString() + "-" + j.ToString();
                    Canvas.SetLeft(padAndInfo.ExampleC, temp.X - 2);
                    Canvas.SetTop(padAndInfo.ExampleC, yLength - temp.Y - 2);
                    CanvasInPath.Children.Add(padAndInfo.ExampleC);
                    list.Add(padAndInfo);
                    temp.Y = (j + 1) * yInterval * ScaleSlider.Value;
                }
                Base.GetInstance().MappingViewModel.PadAndInfoList.Add(list);
                temp.X = (i + 1) * xInterval * ScaleSlider.Value;
            }
            #endregion
        }
        private void DrawROI()
        {
            //CanvasInPath.Children.Clear();
            //int num = rectSelectedPadAndInfos.Count;
            //CanvasInPath.Width = num * xInterval;
            //CanvasInPath.Height = num * yInterval;
            //DrawPadMap(num * xInterval, num * yInterval);
            //int x = GetPadPosition(rectSelectedPadAndInfos[num - 1].ExampleC, xInterval);
            //int y = GetPadPosition(rectSelectedPadAndInfos[num - 1].ExampleC, xInterval);
            //DrawPadMapLabel(x, y, num * xInterval, num * yInterval);
            ////DrawPad();
            //ExampleChanged(num * xInterval, num * yInterval);
            //rectSelectedPadAndInfos.Clear();
        }
        private int GetPadPosition(ExampleC exampleC, double interval)
        {
            return (int)(Canvas.GetLeft(exampleC) / interval / scale);
        }
        /// <summary>
        /// 绘制跟随鼠标移动的方框
        /// </summary>
        private void DrawMultiselectBorder(Point endPoint, Point startPoint)
        {
            if (currentBoxSelectedBorder == null)
            {
                currentBoxSelectedBorder = new Border();
                currentBoxSelectedBorder.Background = new SolidColorBrush(Colors.Orange);
                currentBoxSelectedBorder.Opacity = 0.4;
                currentBoxSelectedBorder.BorderThickness = new Thickness(2);
                currentBoxSelectedBorder.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                Canvas.SetZIndex(currentBoxSelectedBorder, 100);
                this.CanvasInPath.Children.Add(currentBoxSelectedBorder);
            }
            currentBoxSelectedBorder.Width = Math.Abs(endPoint.X - startPoint.X);
            currentBoxSelectedBorder.Height = Math.Abs(endPoint.Y - startPoint.Y);
            if (endPoint.X - startPoint.X >= 0)
                Canvas.SetLeft(currentBoxSelectedBorder, startPoint.X);
            else
                Canvas.SetLeft(currentBoxSelectedBorder, endPoint.X);
            if (endPoint.Y - startPoint.Y >= 0)
                Canvas.SetTop(currentBoxSelectedBorder, startPoint.Y);
            else
                Canvas.SetTop(currentBoxSelectedBorder, endPoint.Y);
        }
        /// <summary>
        /// 获得所有子控件
        /// </summary>
        public static List<T> GetChildObjects<T>(DependencyObject obj) where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if (child is T)
                {
                    childList.Add((T)child);
                }
                childList.AddRange(GetChildObjects<T>(child));
            }
            return childList;
        }

        /// <summary>
        /// 恢复原来状态
        /// </summary>
        private void ReSet_Click(object sender, RoutedEventArgs e)
        {
            List<Rectangle> childList = GetChildObjects<Rectangle>(this.CanvasInPath);
            foreach (var child in childList)
            {
                if (child.Opacity != 1)
                    child.Opacity = 1;
            }
        }
    }
}
