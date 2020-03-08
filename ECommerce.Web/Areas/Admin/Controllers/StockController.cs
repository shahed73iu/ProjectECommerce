using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Services;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using SMS4BD.Core.ViewModels;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class StockController : Controller
    {

        private IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        public IActionResult Index()
        {
            var model = new StockViewModel();
            return View(model);
        }
        public IActionResult GetStocks()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new StockViewModel();
            var data = model.GetStocks(tableModel);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new StockUpdateModel();
            var productModel = new ProductUpdateModel();
            var products = productModel.GetAllProductList();
            ViewBag.ProductList = products;

            var categories = productModel.GetAllCategoryList();
            ViewBag.CategoryList = categories;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(StockUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddStockRecord();
            }
            var products = model.GetAllProductList();
            ViewBag.ProductList = products;
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new StockUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StockUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditStock();
            }
            //return RedirectToAction("Index");
                return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = new StockViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }    
}

