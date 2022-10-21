using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using test.Infomation;

namespace test.ViewModel
{
    public class InfoCompareViewModel : INotifyPropertyChanged
    {
        public InfoCompareViewModel()
        {
            _padInfoList = new ObservableCollection<PadInfo>();
        }
        private ObservableCollection<PadInfo> _padInfoList;
        public ObservableCollection<PadInfo> PadInfoList
        {
            get
            {
                return _padInfoList;
            }
            set
            {
                value = _padInfoList;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("PadInfoList"));
                }
            }
        }
        public void AddPadInfo(PadInfo padInfo)
        {
            padInfo.GlassColumn = 1;
            padInfo.GlassRow = 1;
            PadInfoList.Add(padInfo);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
