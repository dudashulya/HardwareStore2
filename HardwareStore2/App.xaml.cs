using HardwareStore2.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HardwareStore2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareStoreEntities db = new HardwareStoreEntities ();
        public static bool isAdmin = false;
        public static List<Product> products = new List<Product>();
        public static Backet backet;
        public static decimal PricePro = 0;
    }
}
