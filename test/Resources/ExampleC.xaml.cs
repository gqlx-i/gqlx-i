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
using test.Infomation;
using test.View;
using test.ViewModel;

namespace test.Resources
{
    /// <summary>
    /// ExampleC.xaml 的交互逻辑
    /// </summary>
    public partial class ExampleC : UserControl
    {
        public ExampleC()
        {
            InitializeComponent();
        }
        private void ExampleC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Point pp = Mouse.GetPosition(e.Source as Canvas);//WPF方法
            Point ppp = (e.Source as FrameworkElement).PointToScreen(pp);//WPF方法


            {
                MessageBox.Show(string.Format(" GetPosition {0},{1}\r\n {2},{3}", pp.X, pp.Y, ppp.X, ppp.Y));
            }
            Base bs = Base.GetInstance();
            //获取鼠标位置
            bs.InfoCompareViewModel.PadInfoList.Add(new PadInfo());
            if (!bs.InfoCompareWindowIsOpen)
            {
                InfoCompareView infoCompare = new InfoCompareView();
                infoCompare.Show();
                bs.InfoCompareWindowIsOpen = true;
                infoCompare.Closed += (s, e) =>
                {
                    bs.InfoCompareWindowIsOpen = false;
                    bs.InfoCompareViewModel.PadInfoList.Clear();
                };
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)//获取位置
        {

            
        }
    }
}
