using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using test.View;
using test.Common;
using System.Windows;

namespace test.ViewModel
{
    public class OptionsWindowViewModel
    {
        public ICommand CorrelationWindowShowCommand { get; set; }
        public ICommand OptionsWindowHideCommand { get; set; }
        public ICommand ExampleSelectionChangedCommand { get; set; }
        public CorrelationView CorrelationView { get; set; }
        public OptionsWindowViewModel()
        {
            CorrelationWindowShowCommand = new DelegateCommand(CorrelationWindowShow);
            OptionsWindowHideCommand = new DelegateCommand(OptionsWindowHide);
            ExampleSelectionChangedCommand = new DelegateCommand(ExampleSelectionChanged);
        }

        public void CorrelationWindowShow(object obj)
        {
            CorrelationView = new CorrelationView();
            CorrelationView.Show();
        }
        public void OptionsWindowHide(object obj)
        {
            //
            //添加选项恢复
            //
            Base.GetInstance().MappingViewModel.OptionsWindowView.Hide();
        }
        public void ExampleSelectionChanged(object obj)
        {
            MessageBox.Show("图例改变");
        }
    }
}
