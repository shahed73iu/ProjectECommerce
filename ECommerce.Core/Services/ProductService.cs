using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Services
{
    public class ProductService : IProductService
    {
        private IStoreUnitOfWork _storeUnitOfWork;

        public ProductService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewProduct(Product product)
        {
            _storeUnitOfWork.ProductRepositroy.Add(new Product
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Categories = product.Categories,
                Price = product.Price,
            });
            _storeUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _storeUnitOfWork.ProductRepositroy.GetById(id);
            _storeUnitOfWork.ProductRepositroy.Remove(product);
            _storeUnitOfWork.Save();
        }

        public void EditProduct(Product product)
        {
            var oldProduct = _storeUnitOfWork.ProductRepositroy.GetById(product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.Price = product.Price;
            oldProduct.ImageUrl = product.ImageUrl;
            _storeUnitOfWork.Save();
       }

        public Product GetProduct(int id)
        {
            return _storeUnitOfWork.ProductRepositroy.GetById(id);
        }

        public ProductCategory GetProductCategory(int productId)
        {
            return _storeUnitOfWork.ProductCategoryRepository.GetProductCategoryByProductId(productId);
        }

        public IEnumerable<Product> GetProducts(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.ProductRepositroy.Get(
               out total,
               out totalFiltered,
               x => x.Name.Contains(searchText),
               null,
               "",
               pageIndex,
               pageSize,
               true);                
        }
    }
}
