using System;
using System.Collections.Generic;
using System.Text;

namespace test.ViewModel
{
    class MappingViewModel
    {
        public MapChangeItem mcItem { get; set; }
        public List<MapChangeItem> MapChangeList { get; set; } = new List<MapChangeItem>()
        {
            new MapChangeItem(){ Glass="Glass行列显示" }
        };

        public MappingViewModel()
        {

        }
    }

    public class MapChangeItem
    {
        //private string _glass = "Galss行列显示";
        public string Glass { get; set; }
    }
}
