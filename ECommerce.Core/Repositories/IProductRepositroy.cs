﻿using ECommerce.Core.Entities;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public interface IProductRepositroy : IRepository<Product>
    {
        IEnumerable<Product> GetAllProductList();
        Product GetProductByName(string name);
    }
}
