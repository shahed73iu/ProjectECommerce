using ECommerce.Core.Contexts;
using ECommerce.Core.Repositories;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.UnitOfWorks
{
    public class StoreUnitOfWork : UnitOfWork<StoreContext>, IStoreUnitOfWork
    {
        public IProductRepositroy ProductRepositroy { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductCategoryRepository ProductCategoryRepository  { get; set; }

        public StoreUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            ProductRepositroy = new ProductRepository(_dbContext);
            CategoryRepository = new CategoryRepository(_dbContext);
            ProductCategoryRepository = new ProductCategoryRepository(_dbContext);
        }
    }
}
