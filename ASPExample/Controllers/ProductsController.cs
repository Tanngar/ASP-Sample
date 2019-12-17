using ASPExample.Models;
using ASPExample.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPExample.Controllers
{
    public class ProductsController : Controller
    {
        private ASPExampleContext db = new ASPExampleContext();

        // GET: Products
        public ActionResult Index()
        {
            ProductsListViewModel model = new ProductsListViewModel();
            model.Products = db.Products.ToList();
            model.Reviews = db.Reviews.ToList();
            return View(model);
        }

        // GET: Products/Details/:id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Products");
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ProductDetailsViewModel model = new ProductDetailsViewModel();
            model.Product = product;
            model.Reviews = db.Reviews.Where(review => review.ProductId == id).ToList();
            model.ReviewsCount = model.Reviews.Count();

            return View(model);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index", "Products");
            }

            return View(product);
        }
    }
}
