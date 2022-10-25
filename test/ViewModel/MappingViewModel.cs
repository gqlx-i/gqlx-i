using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using test.Common;
using test.Infomation;
using test.View;

namespace test.ViewModel
{
    public class MappingViewModel
    {
        public ICommand OptionWindowShowCommand { get; set; }
        public ICommand SelectWindowShowCommand { get; set; }
        public OptionsWindowView OptionsWindowView { get; set; }
        public SelectWindowView SelectWindowView { get; set; }
        public MapChangeItem mcItem { get; set; }
        public bool ExampleIsChecked { get; set; } = false;
        public bool PathIsChecked { get; set; } = false;
        public List<MapChangeItem> MapChangeList { get; set; } = new List<MapChangeItem>()
        {
            new MapChangeItem(){ TypeName="Glass行列显示" },
            new MapChangeItem(){ TypeName="Wafer行列显示" }
        };
        public List<List<PadAndInfo>> PadAndInfoList { get; set; }
        public int Scale { get; set; }
        public MappingViewModel()
        {
            OptionWindowShowCommand = new DelegateCommand(OptionWindowShow);
            SelectWindowShowCommand = new DelegateCommand(SelectWindowShow);
            PadAndInfoList = new List<List<PadAndInfo>>();
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
    }

    public class MapChangeItem
    {
        public string TypeName { get; set; }
    }
}
