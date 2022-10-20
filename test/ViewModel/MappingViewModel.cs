using System;
using System.Collections.Generic;
using System.Text;

namespace test.ViewModel
{
    class MappingViewModel
    {
        public MapChangeItem mcItem { get; set; }
        public bool ExampleIsChecked { get; set; }
        public bool PathIsChecked { get; set; }
        public List<MapChangeItem> MapChangeList { get; set; } = new List<MapChangeItem>()
        {
            new MapChangeItem(){ GlassWafer="Glass行列显示"},
            new MapChangeItem(){ GlassWafer="Wafer行列显示"}
        };

        public MappingViewModel()
        {
            
        }
    }

    public class MapChangeItem
    {
        //private string _glass = "Galss行列显示";
        public string GlassWafer { get; set; }
    }
}
