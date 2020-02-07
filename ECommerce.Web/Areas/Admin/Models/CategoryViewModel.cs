using ECommerce.Core.Services;
using SMS4BD.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class CategoryViewModel : BaseModel
    {
        private ICategoryService _categoryService;

        public CategoryViewModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public CategoryViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public object GetCategories(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _categoryService.GetCategories(
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
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
