using MachineCode_NimapInfotech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineCode_NimapInfotech.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            try
            {
                int pagesize = 5;
                List<ProductModel> listofProd;
                int count;

                using (var Context = new ContextClass())
                {
                    listofProd = Context.Products.Include("Category").OrderBy(p => p.ProductId).Skip((page - 1) * pagesize).Take(pagesize).ToList();
                    count = Context.Products.Count();
                }

                var productVM = new productViewModel
                {
                    listofProducts = listofProd,
                    TotalRecordsCount = count,
                    PageNumber = page,
                    pagesize = pagesize
                };
                return View(productVM);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                List<CategoryModel> listofCatagories;
                using (var Context = new ContextClass())
                {
                    listofCatagories = Context.Categories.ToList();
                }
                SelectList sl = new SelectList(listofCatagories, "CategoryId", "CategoryName");
                ViewData["listofCatagories"] = sl;
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var Context = new ContextClass())
                    {
                        Context.Products.Add(product);
                        Context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View(product);
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                ProductModel product = null;
                if (id < 1)
                {
                    throw new Exception("No record found for the given id : " + id);
                }
                using (var Context = new ContextClass())
                {
                    product = Context.Products.SingleOrDefault(c => id == c.ProductId);
                }
                if (product == null)
                {
                    throw new Exception("No record found for the given id : " + id);
                }
                return View(product);
            }
            catch (Exception er)
            {
                ViewData["ErrorMessage"] = er.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var Context = new ContextClass())
                    {
                        var pro = Context.Products.SingleOrDefault(c => c.ProductId == product.ProductId);
                        if (pro == null)
                        {
                            throw new Exception("No record found for the given id : " + product.ProductId);
                        }
                        pro.ProductName = product.ProductName;
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
            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                ProductModel product = null;
                if (id < 1)
                {
                    throw new Exception("No record found for the given id : " + id);
                }
                using (var Context = new ContextClass())
                {
                    product = Context.Products.Include("Category").SingleOrDefault(c => c.ProductId == id);
                }

                if (product == null)
                {
                    throw new Exception("No record found for the given id : " + id);
                }
                return View(product);
            }
            catch (Exception er)
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
                ProductModel product = null;

                if (id < 1)
                {
                    throw new Exception("No record found for the given id : " + id);
                }

                using (var Context = new ContextClass())
                {
                    product = Context.Products.SingleOrDefault(c => c.ProductId == id);
                    if (product == null)
                    {
                        throw new Exception("No record found for the given id : " + id);
                    }
                    Context.Products.Remove(product);
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