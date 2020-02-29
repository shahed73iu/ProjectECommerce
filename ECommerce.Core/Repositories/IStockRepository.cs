using ECommerce.Core.Entities;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        Stock GetByProductId(int id);
    }
}
