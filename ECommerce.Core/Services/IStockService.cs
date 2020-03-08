using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Services
{
    public interface IStockService
    {
        Stock GetStockByProductId(int id);
        void AddNewStock(Stock stock);
        void AddExistingStock(Stock stock);
        IEnumerable<Stock> GetStocks(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void DeleteProduct(int id);
        Stock GetStock(int id);
        void EditStock(Stock stock);
    }
}
