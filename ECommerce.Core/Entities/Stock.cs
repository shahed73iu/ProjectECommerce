using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int TotalProductCount { get; set; }
        public int TotalProductSale { get; set; }
        public double TotalAmount { get; set; }
        public IList<Product> Products { get; set; }



        //public int ProductId { get; set; }
        //public Product Product { get; set; }
        // public int OrderId { get; set; }
        // public Order Order { get; set; }

    }
}
