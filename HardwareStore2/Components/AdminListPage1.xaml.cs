﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace HardwareStore2.Components
{
    /// <summary>
    /// Логика взаимодействия для AdminListPage1.xaml
    /// </summary>
    public partial class AdminListPage1 : Page
    {
        public AdminListPage1()
        {
            InitializeComponent();
            MyList.ItemsSource = App.db.Backet.ToList();
            

        }
        
    }
}
