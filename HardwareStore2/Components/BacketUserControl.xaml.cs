﻿using HardwareStore2.Base.PartialClass;
using HardwareStore2.Base;
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
using System.IO;

namespace HardwareStore2.Components
{
    /// <summary>
    /// Логика взаимодействия для BacketUserControl.xaml
    /// </summary>
    public partial class BacketUserControl : UserControl
    {
        public Product product;
        public static List<Product> products = new List<Product>();
        Backet_Product pro1;
        public BacketUserControl(Product _product)
        {
            InitializeComponent();
            product = _product;
            Backet_Product pro = (App.db.Backet_Product.FirstOrDefault(x => x.BacketId == App.backet.Id && x.ProductId == product.Id) as Backet_Product);
            this.DataContext = pro;
            pro1 = pro;
            TttleTB.Text = product.Title;
            CostDiscountTB.Text = product.CostDiscountTB.ToString("N0") + " Р ";
            CostTB.Text = product.Cost.ToString("N0");
            LastCost.Text = product.CostDiscountTB.ToString();
            ImageIMG.Source = GetImageSources(product.MainImage);


        }


        private void BACKETDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
           
            App.products.Remove(product);   
                MessageBox.Show("Запись удалена:  " );
                Navigate.NextPage(new PageComponents("Список услуг", new ListZakazPage()));

          
        }

        private BitmapImage GetImageSources(byte[] byteImage)
        //превращение картинок из байтов в пнг 
        {
            if (product.MainImage != null)
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

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            pro1.Count += 1;
            CountProductTb.Text = (Convert.ToInt32(CountProductTb.Text) + 1).ToString();
            LastCost.Text = (Convert.ToInt32(CountProductTb.Text) * product.CostDiscountTB).ToString();
            pro1.LastCost = (Convert.ToInt32(CountProductTb.Text) * product.CostDiscountTB);
            App.db.SaveChanges();
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (CountProductTb.Text == "1")
            {
                return;
            }
            pro1.Count -= 1;
            CountProductTb.Text = (Convert.ToInt32(CountProductTb.Text) - 1).ToString();
           LastCost.Text = (Convert.ToInt32(CountProductTb.Text) * product.CostDiscountTB).ToString();
            pro1.LastCost = (Convert.ToInt32(CountProductTb.Text) * product.CostDiscountTB);
            App.db.SaveChanges();
        }
    }
}
