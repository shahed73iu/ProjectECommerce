﻿// <auto-generated />
using System;
using ECommerce.Core.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce.Web.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20191023122155_CreateProductRelatedObjects")]
    partial class CreateProductRelatedObjects
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Discount");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Discount");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternativeText");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.FixedAmountDiscount", b =>
                {
                    b.HasBaseType("ECommerce.Core.Entities.Discount");

                    b.HasDiscriminator().HasValue("FixedAmountDiscount");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.PercentageDiscount", b =>
                {
                    b.HasBaseType("ECommerce.Core.Entities.Discount");

                    b.HasDiscriminator().HasValue("PercentageDiscount");
                });

            modelBuilder.Entity("ECommerce.Core.Entities.Discount", b =>
                {
                    b.HasOne("ECommerce.Core.Entities.Product", "Product")
                        .WithOne("PriceDiscount")
                        .HasForeignKey("ECommerce.Core.Entities.Discount", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ECommerce.Core.Entities.ProductCategory", b =>
                {
                    b.HasOne("ECommerce.Core.Entities.Category", "Category")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Core.Entities.Product", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ECommerce.Core.Entities.ProductImage", b =>
                {
                    b.HasOne("ECommerce.Core.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
