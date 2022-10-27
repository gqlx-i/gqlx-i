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
    /// MyCircle.xaml 的交互逻辑
    /// </summary>
    public partial class MyCircle : UserControl
    {
        public MyCircle()
        {
            InitializeComponent();
        }
        private void ExampleC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Base bs = Base.GetInstance();
            int indexX = (int)((Canvas.GetLeft(this) + 5) / bs.MappingViewModel.Scale / 20);
            int indexY = (int)(bs.MappingViewModel.PadAndInfoList[1].Count - 1 - (Canvas.GetTop(this) + 5) / bs.MappingViewModel.Scale / 10);
            PadInfo padinfo = bs.MappingViewModel.PadAndInfoList[indexX][indexY].PadInfo;
            bs.InfoCompareViewModel.PadInfoList.Add(padinfo);
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
    }
}
