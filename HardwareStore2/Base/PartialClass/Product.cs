using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace HardwareStore2.Base
{
    public partial class Product
    {
        
        
            public decimal CostDiscountTB
            {
                get
                {
                    if (Discount == null)
                        return Cost;
                    else
                        return Cost - (Cost * (decimal)Discount / 100);
                }
            }
            
            public Visibility Visibility
            {
                get
                {
                    if (Discount == null)
                        return Visibility.Collapsed;
                    else
                        return Visibility.Visible;
                }

            }

            
           
        }
}
