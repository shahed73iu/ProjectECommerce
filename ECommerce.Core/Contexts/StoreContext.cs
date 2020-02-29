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
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
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


            builder.Entity<Product>()
                .HasOne(p => p.ProductStock)
                .WithOne(d => d.Product);

            //---------------------------------------------------
            /* builder.Entity<ProductStock>()
                .HasKey(pc => new { pc.ProductId, pc.StockId });

             builder.Entity<ProductStock>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(pc => pc.ProductId);

             builder.Entity<ProductStock>()
                 .HasOne(pc => pc.Stock)
                 .WithMany(cd => cd.Products)
                 .HasForeignKey(pc => pc.StockId);
              */
            //---------------------------------------------------
            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
        public DbSet<PercentageDiscount> PercentageDiscounts { get; set; }
        public DbSet<Stock> Stocks { get; set; }

       //* public DbSet<ProductStock> ProductStock { get ; set; }
    }
}
