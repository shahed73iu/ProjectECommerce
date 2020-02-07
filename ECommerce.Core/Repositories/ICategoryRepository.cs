using ECommerce.Core.Entities;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategoryList();
        Category GetCategoryByName(string name);
    }
}
