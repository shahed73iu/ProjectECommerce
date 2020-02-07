using ECommerce.Core.Contexts;
using ECommerce.Core.Entities;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepositroy
    {
        public ProductRepository(IStoreContext productContext)
            : base((StoreContext)productContext)
        {

        }
    }
}
