using ECommerce.Core.Contexts;
using ECommerce.Core.Entities;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
 
        public Stock GetByProductId(int id)
        {
            var stocksRecord = _context.Stocks.Where(x => x.ProductId == id).FirstOrDefault();
            return stocksRecord;
        }
    }
}
