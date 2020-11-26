using MachineCode_NimapInfotech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineCode_NimapInfotech.Controllers
{
    public class CategoryController : Controller
    {
        // GET: List of Categories
        public ActionResult Index()
        {
            try
            {
                List<CategoryModel> listofCateogories=null;
                using (var Context= new ContextClass())
                {
                    listofCateogories = Context.Categories.ToList();
                }
                return View(listofCateogories);
            }
            catch(Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var Context = new ContextClass())
                    {
                        Context.Categories.Add(category);
                        Context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception)
                {
                    return View("Error");
                }
            }
            return View(category);
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                CategoryModel category = null;

                if (id < 1)
                {
                    throw new Exception("No record found for the given id : "+id);
                }

                using (var Context = new ContextClass())
                {
                     category = Context.Categories.SingleOrDefault(c => id == c.CategoryId);
                }

                if (category == null)
                {
                    throw new Exception("No record found for the given id : " + id);
                }

                return View(category);
            }
            catch(Exception er)
            {
                ViewData["ErrorMessage"] = er.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Update(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var Context = new ContextClass())
                    {
                        var cat = Context.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
                        if (cat == null)
                        {
                            throw new Exception("No record found for the given id : " + category.CategoryId);
                        }
                        cat.CategoryName = category.CategoryName;
                        Context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception er)
                {
                    ViewData["ErrorMessage"] = er.Message;
                    return View("Error");
                }
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                CategoryModel category = null;

                if (id < 1)
                {
                    throw new Exception("No record found for the given id : " + id);
                }

                using (var Context = new ContextClass())
                {
                    category = Context.Categories.SingleOrDefault(c => c.CategoryId == id);
                }

                if (category == null)
                {
                    throw new Exception("No record found for the given id : " + id);
                }
                return View(category);

            }
            catch(Exception er)
            {
                ViewData["ErrorMessage"] = er.Message;
                return View("Error");
            }
            
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new Exception("No record found for the given id : " + id);
                }
                using (var Context = new ContextClass())
                {
                    var category = Context.Categories.SingleOrDefault(c => c.CategoryId == id);
                    if (category == null)
                    {
                        throw new Exception("No record found for the given id : " + id);
                    }
                    Context.Categories.Remove(category);
                    Context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception er)
            {
                ViewData["ErrorMessage"] = er.Message;
                return View("Error");
            }

        }

    }
}