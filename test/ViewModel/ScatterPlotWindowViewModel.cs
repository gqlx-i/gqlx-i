using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace test.ViewModel
{
    class ScatterPlotWindowViewModel : INotifyPropertyChanged
    {
        private List<string> _offsetList;
        private string _selectedOffset;
        public ScatterPlotWindowViewModel()
        {
            _offsetList = new List<string>() { "offsetXY", "offsetX", "offsetY" };
            _selectedOffset = "offsetXY";
        }
        public List<string> OffsetList
        {
            get
            {
                return _offsetList;
            }
            set
            {
                value = _offsetList;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("OffsetList"));
                }
            }
        }

        public string SelectedOffset
        {
            get
            {
                return _selectedOffset;
            }
            set
            {
                _selectedOffset = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedOffset"));
                }
            }
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
