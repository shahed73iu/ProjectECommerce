using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ECommerce.Core.Services;
using SMS4BD.Core.ViewModels;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class StockViewModel : BaseModel
    {
        private IStockService _stockService;
        private IProductService _productService;
        public StockViewModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public StockViewModel(IStockService stockService, IProductService productService)
        {
            _stockService = stockService;
            _productService = productService;
        }

      
        public object GetStocks(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _stockService.GetStocks(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);
            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Product.Name,
                                record.TotalProductCount.ToString(),
                                record.TotalProductSale.ToString(),
                                record.TotalAmount.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _stockService.DeleteProduct(id);
        }
    }
}
