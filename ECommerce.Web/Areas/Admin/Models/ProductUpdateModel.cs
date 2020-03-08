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
       // [Required]
        public string Description { get; set; }
        //[Required]
        public Category Category { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile ProductImage { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public IList<ProductImage> Images { get; set; }
        public ProductCategory ProductCategory { get; set; }

        private IProductService _productService;
        private ICategoryService _categoryService;
        private IImageService _imageService;

        
        public ProductUpdateModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            _imageService = Startup.AutofacContainer.Resolve<IImageService>();
        }
        public ProductUpdateModel(IProductService productService ,ICategoryService categoryService, IImageService imageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _imageService = imageService;
            
        }

        public IEnumerable<Product> GetAllProductList()
        {
            return _productService.GetAllProducts();
        }

        public IEnumerable<Category> GetAllCategoryList()
        {
            return _categoryService.GetAllCategories();
        }

        public void AddNewProductItem(string imageUrl)
        {
            try
            {
                var category = _categoryService.GetCategoryByName(this.Category.Name);

                var product = new Product
                {
                    Name = this.Name,
                    Description = this.Description,
                    Price = this.Price,
                    ImageUrl = imageUrl,
                };

                var productCategory = new ProductCategory()
                {
                    Product = product,
                    Category = category
                };
                
                var image = new ProductImage
                {
                    Url = product.ImageUrl,
                    Product = product,
                    AlternativeText = product.Name
                };
                _productService.AddNewProduct(product, image , productCategory);

                Notification = new NotificationModel("Success!", "Product Successfully Added", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
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

        public string ImageUpload(IFormFile productImage)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(productImage.FileName);
            var newFileName = $"{ randomName }{ Path.GetExtension(productImage.FileName)}";
            FileName = newFileName;

            var path = $"wwwroot/upload/{randomName}{Path.GetExtension(productImage.FileName)}";
            FilePath = path;
            if (!System.IO.File.Exists(path))
            {
                using (var imageFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = productImage.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageFile);

                    }
                }
            }
            return newFileName;
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
