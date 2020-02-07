using ECommerce.Core.Contexts;
using ECommerce.Core.Entities;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private StoreContext _context;
        public ProductCategoryRepository(StoreContext dbContext)
            :base(dbContext)
        {
            _context = dbContext;
        }

        public ProductCategory GetProductCategoryByProductId(int productId)
        {
            return _context.ProductCategory.Where(x => x.ProductId == productId).FirstOrDefault();
        }
    }
}
