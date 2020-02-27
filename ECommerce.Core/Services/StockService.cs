using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Services
{
    public class StockService : IStockService
    {
        private IStoreUnitOfWork _storeUnitOfWork;
        public StockService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewStock(Stock stock)
        {
            if (stock.TotalProductCount < 0)
                throw new InvalidOperationException("Total can not be negative");
            _storeUnitOfWork.StockRepository.Add(stock);
            _storeUnitOfWork.Save();
        }
    }
}
