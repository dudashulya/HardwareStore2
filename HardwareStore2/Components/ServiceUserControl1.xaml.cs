
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

namespace HardwareStore2.Components
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl1.xaml
    /// </summary>
    public partial class ServiceUserControl1 : UserControl
    {
        public  ServiceUserControl1(Product product  )

        {
            InitializeComponent();
            TttleTB.Text = product.Title;
            CostDiscountTB.Text = product.CostDiscountTB.ToString("N0") + " Р ";
            CostTB.Text = product.Cost.ToString("N0");
            //CostTb.Visibility = service.Visibility;
            //MainBorder.Background = service.ColorServ;
        }
    }
}
