using isMerkeziSistemi.Entities;
using isMerkeziSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isMerkeziSistemi.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryModel categoryModel = new CategoryModel();
        // GET: Category
        public ActionResult Index()
        {
            ViewBag.category = categoryModel.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View("Add", new Category());
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {

            categoryModel.create(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            categoryModel.delete(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(string id)
        {

            return View("Edit", categoryModel.find(id));
        }

        [HttpPost]
        public ActionResult Edit(Category category, FormCollection fc)
        {
            string id = fc["Id"];
            var cat = categoryModel.find(id);
           
            cat.CategoryName = category.CategoryName;
            cat.Aciklama = category.Aciklama;
            categoryModel.update(cat);
            return RedirectToAction("Index");


        }
    }
}