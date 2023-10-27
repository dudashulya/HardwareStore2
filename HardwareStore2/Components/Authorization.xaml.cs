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
using HardwareStore2.Base.PartialClass;
using HardwareStore2.Base;
using HardwareStore2.Components;

namespace HardwareStore2.Components
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            
            
                if (PasswordPB.Password == "0000")
                {
                    App.isAdmin = true;
                    MessageBox.Show("Здравствуй администратор");
                }
                else
                {
                MessageBox.Show("Здравствуй друг");
            }

            Navigate.NextPage(new PageComponents("Список услуг", new ServicePage()));

        }
    }
}
