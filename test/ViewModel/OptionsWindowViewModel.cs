using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using test.View;
using test.Common;
using System.Windows;
using test.Infomation;
using System.ComponentModel;
using System.Windows.Media;

namespace test.ViewModel
{
    public class OptionsWindowViewModel : INotifyPropertyChanged
    {
        private List<Legend> _hue;
        private List<Legend> _polyline;
        private List<Legend> _arrow;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CorrelationWindowShowCommand { get; set; }
        public ICommand OptionsWindowHideCommand { get; set; }
        public ICommand ExampleSelectionChangedCommand { get; set; }
        public CorrelationView CorrelationView { get; set; }
        public List<Legend> Hue
        {
            get { return _hue; }
            set { _hue = value; this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Hue")); }
        }
        public List<Legend> Polyline
        {
            get { return _polyline; }
            set { _polyline = value; this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Polyline")); }
        }
        public List<Legend> Arrow
        {
            get { return _arrow; }
            set { _arrow = value; this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Arrow")); }
        }
        public OptionsWindowViewModel()
        {
            CorrelationWindowShowCommand = new DelegateCommand(CorrelationWindowShow);
            OptionsWindowHideCommand = new DelegateCommand(OptionsWindowHide);
            ExampleSelectionChangedCommand = new DelegateCommand(ExampleSelectionChanged);
            LegendInit();
        }
        public void LegendInit()
        {
            _hue = new List<Legend>();
            _hue.Add(new Legend() { Name = "Non", IsChecked = true, Color = null });
            _hue.Add(new Legend() { Name = "时间", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "PEX11", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "PEY11", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "PEX21", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "PEY21", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "OffsetX", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "OffsetY", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "PEX12", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "PEY12", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "PEX22", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "PEY22", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "MoveX1", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "MoveY1", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "MoveX2", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "MoveY2", IsChecked = false, Color = null });
            _hue.Add(new Legend() { Name = "InposeTime", IsChecked = false, Color = null });

            _polyline = new List<Legend>();
            _polyline.Add(new Legend() { Name = "PEX11", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "PEY11", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "PEX21", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "PEY21", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "PEX12", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "PEY12", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "PEX22", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "PEY22", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "MoveX1", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "MoveY1", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "MoveX2", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "MoveY2", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "OffsetX", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _polyline.Add(new Legend() { Name = "OffsetY", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });

            _arrow = new List<Legend>();
            _arrow.Add(new Legend() { Name = "PE(X11,Y11)", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _arrow.Add(new Legend() { Name = "PE(X12,Y12)", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _arrow.Add(new Legend() { Name = "Move(X1,Y1)", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _arrow.Add(new Legend() { Name = "VelX1Y1", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _arrow.Add(new Legend() { Name = "Offset(X,Y)", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _arrow.Add(new Legend() { Name = "PE(X21,Y21)", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _arrow.Add(new Legend() { Name = "PE(X22,Y22)", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _arrow.Add(new Legend() { Name = "Move(X2,Y2)", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
            _arrow.Add(new Legend() { Name = "VelX2Y2", IsChecked = false, Color = new SolidColorBrush(Colors.Gray) });
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
