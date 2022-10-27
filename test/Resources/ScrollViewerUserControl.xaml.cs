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

namespace test.Resources
{
    /// <summary>
    /// ScrollViewerUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ScrollViewerUserControl : UserControl
    {
        private bool isCanMove = false;//鼠标是否移动
        private bool isLeftButtonUp = true;
        private bool isRightButtonUp = true;
        private bool isShiftKeyUp=false;
        private Point tempStartPoint;

        public ScrollViewerUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        //private void CanvasInPath_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    isLeftButtonUp = false;
        //    isCanMove = true;
        //    //tempStartPoint = e.GetPosition(this.CanvasInPath);
        //}

        //private void CanvasInPath_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    isRightButtonUp = false;
        //    scrollView.ScrollToTop();
        //    scrollView.PageUp();
        //    scrollView.PageLeft();
        //    //isCanMove = true;
        //    //tempStartPoint = e.GetPosition(this.CanvasInPath);
        //}

        //// Shift按下
        //private void Window_Keydown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyStates == Keyboard.GetKeyStates(Key.LeftShift) || e.KeyStates == Keyboard.GetKeyStates(Key.RightShift))
        //    {
        //        isShiftKeyUp = false;
        //        //this.CanvasInPath.Cursor = Cursors.Cross;
        //    }
        //}

        //public void Restore_Click(object sender, RoutedEventArgs e)
        //{
        //    scrollView.ScrollToTop();
        //    scrollView.PageDown();
        //    scrollView.ScrollToLeftEnd();
        //    scrollView.PageRight();
        //}

        //public void HorizontalScrollBarRepeatButon_Click(object sender, RoutedEventArgs e)
        //{
        //    scrollView.PageRight();
        //    scrollView.ScrollToLeftEnd();
        //}

        //public void VerticalScrollBarRepeatButon_Click(object sender, RoutedEventArgs e)
        //{
        //    scrollView.PageDown();
        //    scrollView.ScrollToTop();
        //}

        //public static void ScrollViewToVerticalTop(FrameworkElement element, ScrollViewer scrollViewer)
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
    }
}
