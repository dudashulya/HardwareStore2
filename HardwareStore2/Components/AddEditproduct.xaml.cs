using HardwareStore2.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditproduct.xaml
    /// </summary>
    public partial class AddEditproduct : Page
    {
        private Product product;
        public AddEditproduct(Product _product)
        {
            product = _product;
            InitializeComponent();
            this.DataContext = product;
        }

        private void ChangeImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jepg|*.jepg"
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                product.MainImage = File.ReadAllBytes(openFileDialog.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();//создание строки ошибки 
            
            if (product.Id == 0)
            {
                if (App.db.Product.Any(x => x.Title == product.Title))
                {
                    error.AppendLine("Такая услуга УЖЕ существует!!!!!!!!!!!!");
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    App.db.Product.Add(product);
                }
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.db.SaveChanges();

            MessageBox.Show("Сохранено");
            NavigationService.Navigate(new ServicePage() );

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, (0)))
            {
                e.Handled = true;
            }
        }
    }
}
