using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using test.Common;
using test.Infomation;
using test.View;

namespace test.ViewModel
{
    public class MappingViewModel : INotifyPropertyChanged
    {
        public ICommand OptionWindowShowCommand { get; set; }
        public ICommand SelectWindowShowCommand { get; set; }
        public OptionsWindowView OptionsWindowView { get; set; }
        public SelectWindowView SelectWindowView { get; set; }
        public bool ExampleIsChecked { get; set; } = false;
        public bool PathIsChecked { get; set; } = false;

        private List<string> _typeNameList;
        private string _selectedTypeName;       
        public List<List<PadAndInfo>> PadAndInfoList { get; set; }
        public int Scale { get; set; }
        public MappingViewModel()
        {
            OptionWindowShowCommand = new DelegateCommand(OptionWindowShow);
            SelectWindowShowCommand = new DelegateCommand(SelectWindowShow);
            PadAndInfoList = new List<List<PadAndInfo>>();
            _typeNameList = new List<string>() { "Glass行列显示", "Wafer行列显示" };
            _selectedTypeName = "Glass行列显示";
        }

        public List<string> TypeNameList
        {
            get
            {
                return _typeNameList;
            }
            set
            {
                value = _typeNameList;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("TypeNameList"));
                }
            }
        }

        public string SelectedTypeName
        {
            get
            {
                return _selectedTypeName;
            }
            set
            {
                _selectedTypeName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedTypeName"));
                }
            }
        }

        public void OptionWindowShow(object obj)
        {
            OptionsWindowView = new OptionsWindowView();
            OptionsWindowView.Show();
        }
        public void SelectWindowShow(object obj)
        {
            SelectWindowView = new SelectWindowView();
            SelectWindowView.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
}
