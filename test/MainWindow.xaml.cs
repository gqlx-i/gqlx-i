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
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
