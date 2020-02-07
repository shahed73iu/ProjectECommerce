using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Services
{
    public interface IProductService
    {
       IEnumerable<Product> GetProducts(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered);
        void AddNewProduct(Product product);
        Product GetProduct(int id);
        ProductCategory GetProductCategory(int productId);
        void EditProduct(Product product);
        void DeleteProduct(int id);
    }

}
