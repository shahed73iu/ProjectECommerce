using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Entities
{
    public class ProductStock
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
