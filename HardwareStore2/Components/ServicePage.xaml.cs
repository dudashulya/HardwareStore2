using HardwareStore2.Base;
using HardwareStore2.Base.PartialClass;
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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            Refresh();
            IEnumerable<Product> List = App.db.Product;
            foreach(Product Item in List)
            {
                ServicesWp.Children.Add(new ServiceUserControl1(Item));
            }
            if (App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
                ListOrders.Visibility = Visibility.Hidden;
            }
            else
            {
                BacketBtn.Visibility = Visibility.Hidden;
            }

        }
        private void Refresh()
        {
            IEnumerable<Product> serviceSortList = App.db.Product;
            if (ShortCB.SelectedIndex != 0)
            {
                if (ShortCB.SelectedIndex == 1)
                {
                    serviceSortList = serviceSortList.OrderBy(x => x.Cost);
                }
                else if (ShortCB.SelectedIndex == 2)
                {
                    serviceSortList = serviceSortList.OrderByDescending(x => x.Cost);
                }
            }
            if (DiscountFilterCb.SelectedIndex != 0)//выводим сортировку комбобокс
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                {
                    serviceSortList = serviceSortList.Where(x => x.Discount == 0 && x.Discount < 2);
                }
                if (DiscountFilterCb.SelectedIndex == 2)
                {
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 2 && x.Discount < 5);
                }
                if (DiscountFilterCb.SelectedIndex == 3)
                {
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 5 && x.Discount < 30);
                }

                if (SerchTb.Text != null)
                {
                    serviceSortList = serviceSortList.Where(x => x.Title.ToLower().Contains(SerchTb.Text.ToLower()) || x.Description.ToLower().Contains(SerchTb.Text.ToLower())); //поиск по слову
                }

                //всегда в конце так как сортировки могут наслаиваться 
                ServicesWp.Children.Clear();
                foreach (var service in serviceSortList)
                {
                    ServicesWp.Children.Add(new ServiceUserControl1(service));



                }




            }

        }

        private void ShortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SerchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.NextPage(new PageComponents("Добавление товаров", new AddEditproduct(new Product())));
        }

        private void BacketBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.NextPage(new PageComponents("Корзина", new BacketPage(null)));
        }

        private void ListOrders_Click(object sender, RoutedEventArgs e)
        {
            Navigate.NextPage(new PageComponents("Корзина", new BacketPage(null)));
        }
    }
}
