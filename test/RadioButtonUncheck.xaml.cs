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

namespace test
{
    /// <summary>
    /// RadioButtonUncheck.xaml 的交互逻辑
    /// </summary>   
    public partial class RadioButtonUncheck : RadioButton
    {
        private bool _lastChecked;
        public RadioButtonUncheck()
        {
            InitializeComponent();
            Click += RadioButtonUncheck_Click; ;
            PreviewMouseDown += RadioButtonUncheck_PreviewMouseDown; ;
            Checked += RadioButtonUncheck_Checked;
            Unchecked += RadioButtonUncheck_Unchecked;
        }

        // 点击事件处理方法
        private void RadioButtonUncheck_Click(object sender, RoutedEventArgs e)
        {
            //SwitchStatus();
        }

        // 鼠标按下事件处理方法
        private void RadioButtonUncheck_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SwitchStatus();
            e.Handled = true;
        }

        // 切换状态
        private void SwitchStatus()
        {
            if (_lastChecked)
            {
                IsChecked = false;
                //_lastChecked = false;
            }
            else
            {
                IsChecked = true;
                //_lastChecked = true;
            }
        }

        // 选中事件 处理方法
        private void RadioButtonUncheck_Checked(object sender, RoutedEventArgs e)
        {
            _lastChecked = true;
        }

        // 取消选中事件 处理方法
        private void RadioButtonUncheck_Unchecked(object sender, RoutedEventArgs e)
        {
            _lastChecked = false;
        }
    }
}
