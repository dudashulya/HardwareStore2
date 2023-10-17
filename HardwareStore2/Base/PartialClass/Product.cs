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
                    if (Discount == 0)
                        return Cost;
                    else
                        return Cost - (Cost * (decimal)Discount / 100);
                }
            }
            
            public Visibility Visibility
            {
                get
                {
                    if (Discount == 0)
                        return Visibility.Collapsed;
                    else
                        return Visibility.Visible;
                }

            }
            
            public string FeedbackText
        {
            get
            {
                double sum = 0;
                foreach(var item in Feedback)
                {
                    sum = sum + item.Evaluation;
                }
                return $"{(sum / Feedback.Count()).ToString("N2")}   {Feedback.Count()} отзыв";
            }
        }

            
           
    }
}
