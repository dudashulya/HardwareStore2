using HardwareStore2.Base;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
    /// Логика взаимодействия для BacketPage.xaml
    /// </summary>
    public partial class BacketPage : Page
    {
        List<Product> products;
        public BacketPage(List<Product> _products)
        {
            InitializeComponent();
            products = _products;
            BacketList.ItemsSource = products.ToList();
        }

        

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
          if(BacketList.SelectedItem != null)
            {
                products.Remove(BacketList.SelectedItem as Product);
                MessageBox.Show("Вы навсегда удаляете этот продукт из корзины. Изменить нельзя!");
            }
            else
            {
                MessageBox.Show(" Выбери продукт");
                
            }
            BacketList.ItemsSource = products.ToList();
            
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (BacketList.SelectedItem != null)
            {
                MessageBox.Show("Спасибо за покупку, мы тестовая версия этого супер приложения. Деньги не возьмем, но лучше не ломайте нас. досвидание.");
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show(" Выбери продукт");
            }
            BacketList.ItemsSource = products.ToList();

        }

        private void BacketList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //FullPrice = priceCloun * (int)Count;
        }

        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            //    try
            //    {
            //        var selItem = (sender as TextBox).DataContext as Backet_Product;
            //        if (Convert.ToDecimal((sender as TextBox).Text) < 1)
            //        {
            //            (sender as TextBox).Text = "1";
            //            MessageBox.Show("Нельзя ввести количество меньше 1-го!!!");
            //        }
            //        selItem.Price = Convert.ToDecimal((sender as TextBox).Text) * Convert.ToDecimal(selItem.Product.FullPrice);
            //        selItem.CountProduct = Convert.ToInt32((sender as TextBox).Text);
            //        App.db.SaveChanges();
            //        BacketList.ItemsSource = App.db.Backet_Product.ToList();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Вы ввели не число, а другой символ!!!");
            //    }
        }
}
}
