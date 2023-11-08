
using HardwareStore2.Base;
using HardwareStore2.Base.PartialClass;
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
    /// Логика взаимодействия для ServiceUserControl1.xaml
    /// </summary>
    public partial class ServiceUserControl1 : UserControl
    { public Product product;
        public  ServiceUserControl1(Product _product  )

        { 
            InitializeComponent();
            product = _product;
            TttleTB.Text = product.Title;
            CostDiscountTB.Text = product.CostDiscountTB.ToString("N0") + " Р ";
            CostTB.Text = product.Cost.ToString("N0");
            FeedbackTb.Text = product.FeedbackText;

            CostTB.Visibility = product.Visibility;
           
            ImageIMG.Source = GetImageSources(product.MainImage);

            if (App.isAdmin == false)
            {
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }

        private BitmapImage GetImageSources(byte[] byteImage)
        //превращение картинок из байтов в пнг 
        {
            if (product .MainImage != null)
            {
                MemoryStream byteStream = new MemoryStream(byteImage);// мемори стрим с потоками байтов, считывать байты и выполнять с ними работу 
                BitmapImage image = new BitmapImage();// отображает картинку в верстке битмапимаге
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                return image;

            }
            return new BitmapImage(new Uri(@"\Resources\noroot.png", UriKind.Relative));

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.NextPage(new PageComponents("Редактирование", new AddEditproduct(product)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (product.Feedback.Count != 0)
            { MessageBox.Show("Удаление запрещено!"); }
            else
            {
                App.db.Product.Remove(product);
                App.db.SaveChanges();
                MessageBox.Show("Запись удалена:  " + product.Title);
                Navigate.NextPage(new PageComponents("Список услуг", new ServicePage()));
                
            }
        }

        private void BacketBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.NextPage(new PageComponents("Добавление в корзину ", new BacketPage()));
            var selBacket = (sender as Button).DataContext as Base.HardwareStoreEntities; App.db.Backet_Product.Add(new Base.Backet_Product() {/* BacketId = selBacket.Title, Count = 1, Product = selBacket.Cost }*/);
            App.db.SaveChanges();
        }
    }
}
