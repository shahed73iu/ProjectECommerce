using ECommerce.Core.Contexts;
using ECommerce.Core.Entities;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepositroy
    {
        private StoreContext _context;
        public ProductRepository(StoreContext dbContext)
            : base(dbContext)
        {
            _context = dbContext; 
        }

        public IEnumerable<Product> GetAllProductList()
        {
            return _context.Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.Include(x=>x.Categories).Where(x => x.Name == name).AsNoTracking().FirstOrDefault();
        }
    }
}
