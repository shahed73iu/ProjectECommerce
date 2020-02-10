using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Contexts
{
    public interface IStoreContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }
        DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
        DbSet<PercentageDiscount> PercentageDiscounts { get; set; }
         //DbSet<Customer> Customers { get; set; }
         //DbSet<Cart> Carts { get; set; }
         //DbSet<Order> Orders { get; set; }
         //DbSet<Stock> Stocks { get; set; }
    }
}
