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
    /// OptionsWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class OptionsWindowView : Window
    {
        public OptionsWindowView()
        {
            InitializeComponent();
            this.DataContext = Base.GetInstance().OptionsWindowViewModel;
        }

        private void Loaded(object sender,RoutedEventArgs e)
        {
            UserControl userControl = new UserControl();
        }

        bool RDBIsChecked = false;
        private void NonRecordedDataBtn_Click(object sender,RoutedEventArgs e)
        {
            if(RDBIsChecked)
            {
                nonRecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                nonRecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void TimeRecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                timeRecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                timeRecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void Pex11RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                pex11RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                pex11RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void Pey11RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                pey11RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                pey11RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void Pex21RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                pex21RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                pex21RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void Pey21RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                pey21RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                pey21RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void OffsetXRecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                offsetXRecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                offsetXRecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void OffsetYRecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                offsetYRecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                offsetYRecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void Pex12RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                pex12RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                pex12RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void Pey12RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                pey12RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                pey12RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void Pex22RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                pex22RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                pex22RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void Pey22RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                pey22RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                pey22RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void MoveX1RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                moveX1RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                moveX1RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void MoveY1RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                moveY1RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                moveY1RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void MoveX2RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                moveX2RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                moveX2RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void MoveY2RecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                moveY2RecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                moveY2RecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }
        }
        private void InposeTimeRecordedDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RDBIsChecked)
            {
                inposeTimeRecordedDataBtn.IsChecked = false;
                RDBIsChecked = false;
            }
            else
            {
                inposeTimeRecordedDataBtn.IsChecked = true;
                RDBIsChecked = true;
            }              
        }
    }    
}
