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

namespace test.View
{
    /// <summary>
    /// MappingView.xaml 的交互逻辑
    /// </summary>
    public partial class MappingView : UserControl
    {
        public void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindowView OpWindow = new OptionsWindowView();
            OpWindow.ShowDialog();
        }

        public MappingView()
        {
            this.DataContext = new MappingViewModel();
            InitializeComponent();
        }
    }
}
