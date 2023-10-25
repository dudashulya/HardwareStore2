using HardwareStore2.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HardwareStore2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //создали переменную  но нечему не равна она формата майнвиндоу
            //var path = @"C:\Users\212112\Desktop\";
            //foreach (var item in App.db.Product.ToArray())
            //{
            //    var fullPath = path + item.MainImagehh;
            //    item.MainImage = File.ReadAllBytes(fullPath);
            //}
            //App.db.SaveChanges(); //запись картинов в байтах в бд, делать перед преобразованием 
            MainFrame.Navigate(new ServicePage());
        }
    }
}
