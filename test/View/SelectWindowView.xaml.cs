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
using test.ViewModel;

namespace test.View
{
    /// <summary>
    /// SelectWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class SelectWindowView : Window
    {
        public SelectWindowView()
        {
            InitializeComponent();
            this.DataContext = new SelectWindowViewModel();
        }

        public void ScatterPlot_Click(object sender, RoutedEventArgs e)
        {
            ScatterPlotWindowView scatterPlotWindow = new ScatterPlotWindowView();
            scatterPlotWindow.ShowDialog();
        }

        public void CloseWindow_Click(object sender,RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
