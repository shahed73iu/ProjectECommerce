using Autofac;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class StockUpdateModel : BaseModel
    {
        public int Id { get; set; }
        [Required]
        public int TotalProductCount { get; set; }
        public int TotalProductSale { get; set; }
        public double TotalAmount { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }


        private IProductService _productService;
        private ICategoryService _categoryService;
        private IStockService _stockService;
        public StockUpdateModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
                    }
        public StockUpdateModel(IProductService productService , IStockService stockService , ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _stockService = stockService;
        }

        public IEnumerable<Product> GetAllProductList()
        {
            return _productService.GetAllProducts();
        }

        public void AddNewStockRecord()
        {
            try
            {
                var product = _productService.GetProductByName(this.Product.Name);
                _stockService.AddNewStock(new Stock
                {
                    Id = product.Id,
                    TotalProductCount = this.TotalProductCount
                    //Products = new List<Product>()
                    //{
                    //    new Product
                    //    {
                    //        Id = product.Id
                    //    }
                    //}

                });
                Notification = new NotificationModel("Success!", "Stock Successfully Added", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel("Failed!", "Failed to Add Stock, please provide stock details", NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel("Failed!!", "Failed to Add Stock , please try again with valid details", NotificationType.Fail);
            }
        }
    }
}
