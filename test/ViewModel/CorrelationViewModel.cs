﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace test.ViewModel
{
    public class CorrelationViewModel : INotifyPropertyChanged
    {
        public CorrelationViewModel()
        {
            _xLabelList = new List<string>() { "OffsetX", "OffsetY", "PEX11", "PEY11",
                "PEX12", "PEY12", "PEX21", "PEY21", "PEX22", "PEY22", "MoveX1",
                "MoveY1", "MoveX2", "MoveY2" };
            _selectedXLabel = "OffsetX";
        }
        private List<string> _xLabelList;
        private string _selectedXLabel;
        public List<string> XLabelList
        {
            get
            {
                return _xLabelList;
            }
            set
            {
                value = _xLabelList;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("XLabelList"));
                }
            }
        }
        public string SelectedXLabel
        {
            get
            {
                return _selectedXLabel;
            }
            set
            {
                _selectedXLabel = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedXLabel"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}