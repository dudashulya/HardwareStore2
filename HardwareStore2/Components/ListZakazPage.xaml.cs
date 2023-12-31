﻿using HardwareStore2.Base;
using System;
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
    /// Логика взаимодействия для ListZakazPage.xaml
    /// </summary>
    public partial class ListZakazPage : Page
    {
        public ListZakazPage()
        {
            InitializeComponent();
            Refresh();
        }

        //private void Updateit()
        //{
        //    decimal price = 0;
        //    foreach (Product products in Product)
        //    {
        //        price += products.Cost;
        //    }
        //    itogTB.Text = price.ToString();
        //}
        private void Refresh()
        {
          
            ServicesWp.Children.Clear();
            foreach (var service in App.products)
            {
                ServicesWp.Children.Add(new BacketUserControl(service));

            }

        }

        private void ZakazListBtn_Click(object sender, RoutedEventArgs e)
        {
            decimal Sum = 0;
            foreach(var item in App.db.Backet_Product.Where(x => x.BacketId == App.backet.Id))
            {
                Sum += Convert.ToDecimal(item.LastCost);
            }
            MessageBox.Show($"{Sum}");
            MessageBox.Show("Сохранено");
            NavigationService.Navigate(new ServicePage());
        }
    }
}
