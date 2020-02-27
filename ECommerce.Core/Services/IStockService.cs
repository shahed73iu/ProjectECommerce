using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Services
{
    public interface IStockService
    {
        void AddNewStock(Stock stock);
    }
}
