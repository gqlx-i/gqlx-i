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
        private List<string> _typeNameList;
        private string _selectedTypeName;
        private List<string> _waferIdList;
        private string _selectedWaferId;
        private bool _exampleIsChecked;
        private bool _pathIsChecked;
        private bool _isWafer;
        public bool ExampleIsChecked
        {
            get { return _exampleIsChecked; }
            set { _exampleIsChecked = value; this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ExampleIsChecked")); }
        }
        public bool PathIsChecked
        {
            get { return _pathIsChecked; }
            set { _pathIsChecked = value; this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("PathIsChecked")); }
        }
        public List<List<PadAndInfo>> PadAndInfoList { get; set; }
        public ICommand OptionWindowShowCommand { get; set; }
        public ICommand SelectWindowShowCommand { get; set; }
        public OptionsWindowView OptionsWindowView { get; set; }
        public SelectWindowView SelectWindowView { get; set; }
        public int Scale { get; set; }
        public MappingViewModel()
        {
            OptionWindowShowCommand = new DelegateCommand(OptionWindowShow);
            SelectWindowShowCommand = new DelegateCommand(SelectWindowShow);
            PadAndInfoList = new List<List<PadAndInfo>>();
            _typeNameList = new List<string>() { "Glass行列显示", "Wafer行列显示" };
            _selectedTypeName = "Glass行列显示";
            _exampleIsChecked = false;
            _pathIsChecked = false;
            _waferIdList = new List<string>() { "01", "02" };
            _selectedWaferId = "01";
            _isWafer = false;
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
                if (value == "Wafer行列显示")
                {
                    IsWafer = true;
                }
                else
                {
                    IsWafer = false;
                }
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedTypeName"));
                }
            }
        }

        public List<string> WaferIdList
        {
            get
            {
                return _waferIdList;
            }
            set
            {
                value = _waferIdList;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("WaferIdList"));
                }
            }
        }

        public string SelectedWaferId
        {
            get
            {
                return _selectedWaferId;
            }
            set
            {
                _selectedWaferId = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedWaferId"));
                }
            }
        }

        public bool IsWafer
        {
            get
            {
                return _isWafer;
            }
            set
            {
                _isWafer = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsWafer"));
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
