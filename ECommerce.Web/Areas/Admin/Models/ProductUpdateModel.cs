using Autofac;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductUpdateModel : BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public Category Category { get; set; }
        public IFormFile Image { get; set; }
        public IList<ProductImage> Images { get; set; }

        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductUpdateModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }
        public ProductUpdateModel(IProductService productService)
        {
            _productService = productService;
        }
        public IEnumerable<Category> GetAllCategoryList()
        {
            return _categoryService.GetAllCategories();
        }
        public void AddNewProduct(string uniqueFilePath)
        {
            try
            {
                var category = _categoryService.GetCategoryByName(this.Category.Name);
                _productService.AddNewProduct(new Product
                {
                    Name = this.Name,
                    Price = this.Price,
                    Description = this.Description,
                    ImageUrl = uniqueFilePath,
                    Categories = new List<ProductCategory>()
                    {
                        new ProductCategory
                        {
                            CategoryId = category.Id
                        }
                    }
                });
                Notification = new NotificationModel("Success!", "Product Successfully Added", NotificationType.Success);
            }
            catch(InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to Add Product, please provide valide name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!!",
                    "Failed to Add Product , please try again with valid details",
                    NotificationType.Fail);                
            }
        }

        public void EditProduct()
        {
            try
            {
                var product = _productService.GetProduct(this.Id);
                _productService.EditProduct(new Product
                {
                    Id = this.Id,
                    Description = this.Description,
                    Name = this.Name,
                    Price = this.Price,
                   // ImageUrl = this.ImageUrl
                });
                Notification = new NotificationModel("Success!", "Product Successfully Updated!", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create product, please provide valid details!",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create product, please try again!",
                    NotificationType.Fail);
            }
            
        }
        public string GetUploadedImage(string imageFileName)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(imageFileName);
           // var path = $"{randomName}{Path.GetExtension(imageFileName)}";

           var path = $"wwwroot/images/{randomName}{Path.GetExtension(imageFileName)}";

            if (!System.IO.File.Exists(path))
            {
                using (var imageFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = Image.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageFile);

                    }
                }
            }
            return path;
        }

        public void Load(int id)
        {
            var product = _productService.GetProduct(id);
            var productCategory = _productService.GetProductCategory(id);
            var category = _categoryService.GetCategory(productCategory.CategoryId);

            if(product != null)
            {
                Id = product.Id;
                Name = product.Name;
                Description = product.Description;
                Price = product.Price;
                Category = new Category
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }
    }
}
