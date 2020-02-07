using ECommerce.Core.Contexts;
using ECommerce.Core.Repositories;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.UnitOfWorks
{
    public interface IStoreUnitOfWork : IUnitOfWork<StoreContext>
    {
        IProductRepositroy ProductRepositroy { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        IProductCategoryRepository ProductCategoryRepository { get; set; }

    }
}
