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

        public void AddExistingStock(Stock stock)
        {
            var oldStock = _storeUnitOfWork.StockRepository.GetById(stock.Id);
            oldStock.TotalProductCount += stock.TotalProductCount;
            oldStock.TotalAmount = stock.TotalAmount;
            oldStock.TotalProductSale = stock.TotalProductSale;
            
            _storeUnitOfWork.Save();
        }

        public void AddNewStock(Stock stock)
        {
            if (stock.TotalProductCount < 0)
                throw new InvalidOperationException("Total can not be negative");
       
            _storeUnitOfWork.StockRepository.Add(new Stock
            {
              TotalAmount = stock.TotalAmount,
              TotalProductCount = stock.TotalProductCount,
              TotalProductSale = stock.TotalProductSale,
              ProductId = stock.ProductId
            }); 
            _storeUnitOfWork.Save();
        }

        public Stock GetStockByProductId(int id)
        {
            return _storeUnitOfWork.StockRepository.GetByProductId(id);
        }
    }
}
