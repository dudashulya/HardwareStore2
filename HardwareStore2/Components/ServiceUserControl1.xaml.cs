
using HardwareStore2.Base;
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
    }
}
