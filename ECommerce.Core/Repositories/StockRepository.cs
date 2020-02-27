using ECommerce.Core.Contexts;
using ECommerce.Core.Entities;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public class StockRepository : Repository<Stock> , IStockRepository
    {
        private StoreContext _context;
        public StockRepository(StoreContext dbContext)
            :base(dbContext)
        {
            _context = dbContext;
        }
    }
}
