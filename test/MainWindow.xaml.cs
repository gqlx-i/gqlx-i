using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Border currentBoxSelectedBorder = null;//拖动展示的提示框
        private bool isCanMove = false;//鼠标是否移动
        private bool isLeftButtonUp = true;
        private bool isShiftKeyUp = true;
        private Point tempStartPoint;
        public MainWindow()
        {
            InitializeComponent();
            DrawAxisAndText();
        }

        /// <summary>
        /// 转换Canvas坐标
        /// </summary>
        /// <param value="坐标轴的刻度"></param>
        /// <returns></returns>
        private double TransFromX(double value)
        {
            return (double)(((decimal)value / 10) * (decimal)(CanvasInPath.Width) / 10/* - (decimal)XOffset*/);
        }
        private double TransFromY(double value)
        {
            return (double)(((decimal)value / 10) * (decimal)(CanvasInPath.Height) / 10/* - (decimal)YOffset*/);
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

        ///// <summary>
        ///// 尺寸改变,重绘
        ///// </summary>
        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    if (this.Width != 500 || this.Height != 600)
        //    {
        //        double[] dot1value = GetValueOfAxis(DutyCycleCurveDot1);
        //        double[] dot2value = GetValueOfAxis(DutyCycleCurveDot2);

        //        CanvasInPath.Children.Clear();
        //        CanvasInPath.Height = this.ActualHeight - 100;
        //        CanvasInPath.Width = this.ActualWidth;
        //        MaxCoordinateAxisX = this.ActualWidth;
        //        MaxCoordinateAxisY = this.ActualHeight - 100;
        //        CanvasInPath.Children.Add(DutyCycleCurveDot1);
        //        CanvasInPath.Children.Add(DutyCycleCurveDot2);
        //        CanvasInPath.Children.Add(DutyCycleLineList[0]);
        //        CanvasInPath.Children.Add(DutyCycleLineList[1]);
        //        CanvasInPath.Children.Add(DutyCycleLineList[2]);
        //        DrawAxisAndText();
        //        SetDotPosition(DutyCycleCurveDot1, dot1value[0], dot1value[1]);
        //        SetDotPosition(DutyCycleCurveDot2, dot2value[0], dot2value[1]);
        //        UpdateLineAndDot(DutyCycleDotList, DutyCycleLineList);
        //    }
        //}

        /// <summary>
        /// 绘制坐标轴和刻度
        /// </summary>
        private void DrawAxisAndText()
        {
            //坐标线
            Line lineX = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeDashArray = new DoubleCollection(6),
                StrokeThickness = 1,
            };
            Canvas.SetZIndex(lineX, 0);

            lineX.X1 = 0;
            lineX.X2 = 0;
            lineX.Y1 = 0;
            lineX.Y2 = CanvasInPath.Height;

            CanvasInPath.Children.Add(lineX);

            Line lineY = new Line()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeDashArray = new DoubleCollection(6),
                StrokeThickness = 1,
            };
            Canvas.SetZIndex(lineY, 0);
            lineY.X1 = 0;
            lineY.X2 = CanvasInPath.Width;
            lineY.Y1 = (double)(decimal)CanvasInPath.Height;
            lineY.Y2 = (double)(decimal)CanvasInPath.Height;
            CanvasInPath.Children.Add(lineY);
            for (int i = 0, j = 0; i < 10; ++i)
            {
                //刻度
                TextBlock xblock = new TextBlock();
                xblock.Foreground = new SolidColorBrush(Colors.Black);
                xblock.FontSize = 10;
                xblock.Text = i * 10 + "";
                Canvas.SetLeft(xblock, TransFromX(i * 10));
                Canvas.SetTop(xblock, CanvasInPath.Height);
                CanvasInPath.Children.Add(xblock);
                Canvas.SetZIndex(xblock, 1);

                j = 10 - i;

                TextBlock yblock = new TextBlock();
                yblock.Foreground = new SolidColorBrush(Colors.Black);
                yblock.FontSize = 10;
                //translateTransform = new TranslateTransform(0, yblock.ActualWidth);
                //scaleTransform = new ScaleTransform();
                //scaleTransform.ScaleY = 1;
                //transformGroup = new TransformGroup();
                //transformGroup.Children.Add(translateTransform);
                //transformGroup.Children.Add(scaleTransform);
                //yblock.RenderTransform = transformGroup;

                yblock.Text = j * 10 + "";
                Canvas.SetLeft(yblock, 0);
                Canvas.SetTop(yblock, TransFromY(i * 10));
                CanvasInPath.Children.Add(yblock);
                Canvas.SetZIndex(yblock, 1);
            }
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
                currentBoxSelectedBorder.BorderBrush = new SolidColorBrush(Colors.OrangeRed);
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
        public static List<T> GetChildObjects<T>(System.Windows.DependencyObject obj) where T : System.Windows.FrameworkElement
        {
            System.Windows.DependencyObject child = null;
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
