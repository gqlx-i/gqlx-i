using System;
using System.Collections.Generic;
using System.Text;
using test.ViewModel;

namespace test
{
    public class Base
    {
        // 定义一个静态变量来保存类的实例
        private static Base uniqueInstance;
        public bool InfoCompareWindowIsOpen { get; set; } = false;
        public InfoCompareViewModel InfoCompareViewModel { get; set; }
        public CorrelationViewModel CorrelationViewModel { get; set; }
        public OptionsWindowViewModel OptionsWindowViewModel { get; set; }
        public MappingViewModel MappingViewModel { get; set; }
        public GraphWindowViewModel GraphWindowViewModel { get; set; }

        // 定义私有构造函数，使外界不能创建该类实例
        private Base()
        {
            InfoCompareViewModel = new InfoCompareViewModel();
            CorrelationViewModel = new CorrelationViewModel();
            OptionsWindowViewModel = new OptionsWindowViewModel();
            MappingViewModel = new MappingViewModel();
            GraphWindowViewModel = new GraphWindowViewModel();
        }
        public static Base GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (uniqueInstance == null)
            {
                uniqueInstance = new Base();
            }
            return uniqueInstance;
        }
    }
}
