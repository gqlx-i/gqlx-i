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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        private bool isShiftKeyUp = true;
        private Border currentBoxSelectedBorder = null;//拖动展示的提示框
        private Point tempStartPoint;
        private int yMaxValue = 10;
        private int yInterview = 10;
        private int xMaxValue = 10;
        private int xInterview = 10;
        private int LargePx = 10;
        private int ShortPx = 5;
        public void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindowView OpWindow = new OptionsWindowView();
            OpWindow.ShowDialog();
        }

        public MappingView()
        {
            this.DataContext = new MappingViewModel();
            InitializeComponent();
            DrawAxisAndText();
            ExampleChanged();
        }
        public void Select_Click(object sender, RoutedEventArgs e)
        {
           
        }
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
                List<Rectangle> childList = GetChildObjects<Rectangle>(this.CanvasInPath);
                foreach (var child in childList)
                {
                    //获取子控件矩形位置
                    Rect childRect = new Rect(Canvas.GetLeft(child), Canvas.GetTop(child), child.Width, child.Height);
                    //若子控件与选框相交则改变样式
                    if (childRect.IntersectsWith(tempRect))
                        child.Opacity = 0.4;
                }
                this.CanvasInPath.Children.Remove(currentBoxSelectedBorder);
                currentBoxSelectedBorder = null;
            }

            isCanMove = false;
        }
        #endregion
        /// <summary>
        /// 转换Canvas坐标
        /// </summary>
        /// <param value="坐标轴的刻度"></param>
        /// <returns></returns>
        private double TransFromX(double value)
        {
            return (double)((decimal)value / 10 * (decimal)CanvasInPath.Width / 10);
        }
        private double TransFromY(double value)
        {
            return (double)((decimal)value / 10 * (decimal)CanvasInPath.Height / 10);
        }

        /// <summary>
        /// 获取小球的坐标轴刻度
        /// </summary>
        /// <param dot="小球对象"></param>
        /// <returns></returns>
        private double[] GetValueOfAxis(Ellipse dot)
        {
            double x1 = (double)((decimal)(Canvas.GetLeft(dot)/* + XOffset*/) / (decimal)(CanvasInPath.Width / 100));
            double y1 = (double)((decimal)(Canvas.GetTop(dot)/* + YOffset*/) / (decimal)(CanvasInPath.Height / 100));
            return new double[2] { x1, y1 };
        }
        /// <summary>
        /// 绘制坐标轴和刻度
        /// </summary>
        private void DrawAxisAndText()
        {
            //坐标线
            Line lineX = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 1,
            };
            lineX.X1 = 0;
            lineX.X2 = 0;
            lineX.Y1 = 0;
            lineX.Y2 = CanvasInPath.Height;
            CanvasInPath.Children.Add(lineX);

            Line lineY = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 1,
            };
            lineY.X1 = 0;
            lineY.X2 = CanvasInPath.Width;
            lineY.Y1 = (double)(decimal)CanvasInPath.Height;
            lineY.Y2 = (double)(decimal)CanvasInPath.Height;
            CanvasInPath.Children.Add(lineY);

            //轴标Y
            TextBlock yAxisLabel = new TextBlock();
            yAxisLabel.Foreground = new SolidColorBrush(Colors.Black);
            yAxisLabel.FontSize = 12;
            yAxisLabel.Text = "column";
            yAxisLabel.LayoutTransform = new RotateTransform()
            {
                Angle = 90,
            };
            Canvas.SetLeft(yAxisLabel, -50);
            Canvas.SetTop(yAxisLabel, TransFromY(yMaxValue * yInterview / 2));
            CanvasInPath.Children.Add(yAxisLabel);
            //轴标X
            TextBlock xAxisLabel = new TextBlock();
            xAxisLabel.Foreground = new SolidColorBrush(Colors.Black);
            xAxisLabel.FontSize = 12;
            xAxisLabel.Text = "row";
            Canvas.SetLeft(xAxisLabel, TransFromX(xMaxValue * xInterview / 2));
            Canvas.SetTop(xAxisLabel, CanvasInPath.Height + 20);

            CanvasInPath.Children.Add(xAxisLabel);
            #region 刻度线
            for (int i = 0; i < yInterview * yMaxValue; ++i)
            {
                if (i != 0)
                {
                    TextBlock yblock = new TextBlock();
                    yblock.Foreground = new SolidColorBrush(Colors.Black);
                    yblock.FontSize = 10;
                    yblock.Text = i + "";
                    Canvas.SetLeft(yblock, -25);
                    Canvas.SetTop(yblock, TransFromY(100 - i));
                    CanvasInPath.Children.Add(yblock);
                    if (i % yInterview == 0)
                    {
                        Line ly = new Line()
                        {
                            Stroke = new SolidColorBrush(Colors.Black),
                            StrokeThickness = 1,
                        };
                        ly.X1 = 0;
                        ly.X2 = LargePx;
                        ly.Y1 = TransFromY(i);
                        ly.Y2 = TransFromY(i);
                        CanvasInPath.Children.Add(ly);
                    }
                    else
                    {
                        Line ly = new Line()
                        {
                            Stroke = new SolidColorBrush(Colors.Black),
                            StrokeThickness = 1,
                        };
                        ly.X1 = 0;
                        ly.X2 = ShortPx;
                        ly.Y1 = TransFromY(i);
                        ly.Y2 = TransFromY(i);
                        CanvasInPath.Children.Add(ly);
                    }
                }
            }
            for (int i = 0; i < xMaxValue * xInterview; ++i)
            {
                TextBlock xblock = new TextBlock();
                xblock.Foreground = new SolidColorBrush(Colors.Black);
                xblock.FontSize = 10;
                xblock.Text = i + "";
                Canvas.SetLeft(xblock, TransFromX(i));
                Canvas.SetTop(xblock, CanvasInPath.Height);
                CanvasInPath.Children.Add(xblock);
                if (i % xInterview == 0)
                {
                    Line lx = new Line()
                    {
                        Stroke = new SolidColorBrush(Colors.Black),
                        StrokeThickness = 1,
                    };
                    lx.X1 = TransFromX(i);
                    lx.X2 = TransFromX(i);
                    lx.Y1 = CanvasInPath.Height;
                    lx.Y2 = CanvasInPath.Height - LargePx;
                    CanvasInPath.Children.Add(lx);
                }
                else
                {
                    Line lx = new Line()
                    {
                        Stroke = new SolidColorBrush(Colors.Black),
                        StrokeThickness = 1,
                    };
                    lx.X1 = TransFromX(i);
                    lx.X2 = TransFromX(i);
                    lx.Y1 = CanvasInPath.Height;
                    lx.Y2 = CanvasInPath.Height - ShortPx;
                    CanvasInPath.Children.Add(lx);
                }
            }
            #endregion

        }
        //图例改变触发事件
        private void ExampleChanged()
        {
            #region Pad
            for (int i = 1; i < xInterview * xMaxValue; ++i)
            {
                for (int j = 1; j < yInterview * yMaxValue; ++j)
                {
                    ExampleC exampleC = new ExampleC();
                    Canvas.SetLeft(exampleC, TransFromX(i - 0.2));
                    Canvas.SetTop(exampleC, TransFromY(100 - j - 0.25));
                    CanvasInPath.Children.Add(exampleC);
                }
            }
            #endregion
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
