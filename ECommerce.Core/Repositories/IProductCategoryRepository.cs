using ECommerce.Core.Entities;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        ProductCategory GetProductCategoryByProductId(int productId);
    }
}
