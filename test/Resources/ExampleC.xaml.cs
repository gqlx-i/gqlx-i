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
            Base bs = Base.GetInstance();
            bs.InfoCompareViewModel.AddPadInfo(new PadInfo());
            if (!bs.InfoCompareWindowIsOpen)
            {
                InfoCompareView infoCompare = new InfoCompareView();
                infoCompare.Show();
                bs.InfoCompareWindowIsOpen = true;
                infoCompare.Closed += (s, e) => bs.InfoCompareWindowIsOpen = false;
            }
        }
    }
}
