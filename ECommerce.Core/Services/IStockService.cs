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
    }
}
