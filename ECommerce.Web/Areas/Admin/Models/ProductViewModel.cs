﻿using Autofac;
using ECommerce.Core.Services;
using SMS4BD.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductViewModel : BaseModel
    {
        private IProductService _productService;
        public ProductViewModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
        }

        public object GetProducts(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _productService.GetProducts(
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
                                record.Name,
                                record.Price.ToString(),
                                record.Description,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
