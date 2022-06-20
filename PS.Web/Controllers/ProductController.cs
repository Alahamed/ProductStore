using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Domain;
using PS.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productServices;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productServices,
            ICategoryService categoryService)
        {
            this.productServices = productServices;
            this.categoryService = categoryService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var products = productServices.GetMany().ToList(); 
            return View(products);
        }

        [HttpPost]
        public ActionResult Index(string Search)
        {
            List<Product> products;
            if (!string.IsNullOrEmpty(Search))
            {
                products = productServices.GetMany(p => p.Name.Contains(Search)).ToList();
            }
            else

            { products = productServices.GetMany().ToList(); }
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var categories = categoryService.GetMany().ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryKey", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, IFormFile FileImage)
        {
            try
            {
                if (FileImage != null)
                {
                    product.Image = FileImage.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", FileImage.FileName);
                    using (Stream stream= new FileStream(path,FileMode.Create)) {
                        FileImage.CopyTo(stream);
                    }
                }
                productServices.Add(product);
                productServices.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = categoryService.GetMany().ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryKey", "Name");
            return View(productServices.GetById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product, IFormFile FileImage)
        {
            try
            {
                var product1 = productServices.GetById(id);

                product1.Name = product.Name;

                productServices.Update(product1);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
