using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Services;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS4BD.Core.ViewModels;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var model = new ProductViewModel();
            return View(model);
        }
        public IActionResult GetProducts()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductViewModel();
            var data = model.GetProducts(tableModel);
            return Json(data);
        }
        public IActionResult Add()
        {
            var model = new ProductUpdateModel();
            var categories = model.GetAllCategoryList();
            ViewBag.CategoryList = categories;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.ImageUpload(model.ProductImage);
                model.AddNewProductItem();
            }

            var categories = model.GetAllCategoryList();
            ViewBag.CategoryList = categories;
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Add(ProductUpdateModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string path = null;
        //        if (model.Image != null)
        //        {
        //            path = model.GetUploadedImage(model.Image.FileName);
        //        }
        //        model.AddNewProduct(path);
        //    }
        //    var categories = model.GetAllCategoryList();
        //    ViewBag.CategoryList = categories;
        //    return View(model);
        //}


        public IActionResult Edit(int id)
        {
            var model = new ProductUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductUpdateModel model)
        {
           if (ModelState.IsValid)
            {
                model.EditProduct();
            }
            return RedirectToAction("Index");
            //return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = new ProductViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}