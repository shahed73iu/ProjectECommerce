using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Entities
{
    public class PercentageDiscount : Discount
    {
        public override double CalculatePriceAfterDiscount(double price)
        {
            return price * Amount / 100.0;
        }
    }
}
