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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private StoreContext _context;
        public CategoryRepository(StoreContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Category> GetAllCategoryList()
        {
            return _context.Category.ToList();
        }

        public Category GetCategoryByName(string name)
        {
            return _context.Category.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
