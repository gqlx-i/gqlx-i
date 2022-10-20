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
    /// CorrelationView.xaml 的交互逻辑
    /// </summary>
    public partial class CorrelationView : Window
    {
        private double xInterval = 1;
        private double yInterval = 0.2;
        public CorrelationView()
        {
            this.DataContext = new CorrelationViewModel();
            InitializeComponent();
            DrawCorrelationMap();
        }
        private void DrawCorrelationMap()
        {

        }
    }
}
