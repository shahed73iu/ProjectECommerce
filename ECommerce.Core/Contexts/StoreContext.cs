using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Contexts
{
    public class StoreContext : DbContext, IStoreContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public StoreContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product);

            builder.Entity<Product>()
                .HasOne(p => p.PriceDiscount)
                .WithOne(d => d.Product);

            builder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.ProductId);

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(cd => cd.Categories)
                .HasForeignKey(pc => pc.CategoryId);


            builder.Entity<Stock>()
                .HasMany(p => p.Products)
                .WithOne(f => f.Stock);


            //builder.Entity<Customer>()
            //    .HasMany(cl => cl.Carts)
            //    .WithOne(pp => pp.Customer);

            //builder.Entity<Cart>()
            //    .HasMany(pr => pr.Products)
            //    .WithOne(cr => cr.Cart);

            //builder.Entity<Cart>()
            //  .HasOne(p => p.Order)
            //  .WithOne(d => d.Cart);

            //builder.Entity<Stock>()
            //.HasOne(p => p.Order)
            //.WithOne(d => d.Stock);


            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
        public DbSet<PercentageDiscount> PercentageDiscounts { get; set; }
        public DbSet<Stock> Stocks { get; set; }


        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<Order> Orders { get; set; }
    }
}
