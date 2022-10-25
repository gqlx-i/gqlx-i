using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace test.ViewModel
{
    public class GraphWindowViewModel: INotifyPropertyChanged
    {
        private List<string> _markRuleList;
        private List<string> _offsetList;
        private string _selectedOffset;
        private string _selectedMarkRule;

        public GraphWindowViewModel()
        {
            SeriesVisibilityX = true;
            SeriesVisibilityY = true;

            _offsetList = new List<string>() { "offsetXY", "offsetX", "offsetY" };
            _selectedOffset = "offsetXY";
            _markRuleList = new List<string>() { "逐个" };
            _selectedMarkRule = "逐个";
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

        public List<string> MarkRuleList
        {
            get
            {
                return _markRuleList;
            }
            set
            {
                value = _markRuleList;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MarkRuleList"));
                }
            }
        }
        public string SelectedMarkRule
        {
            get
            {
                return _selectedMarkRule;
            }
            set
            {
                _selectedMarkRule = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedMarkRule"));
                }
            }
        }


        private bool _seriesVisibilityX;
        private bool _seriesVisibilityY;

        public bool SeriesVisibilityX
        {
            get { return _seriesVisibilityX; }
            set
            {
                _seriesVisibilityX = value;
                OnPropertyChanged("SeriesVisibilityX");
            }
        }

        public bool SeriesVisibilityY
        {
            get { return _seriesVisibilityY; }
            set
            {
                _seriesVisibilityY = value;
                OnPropertyChanged("SeriesVisibilityY");
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
