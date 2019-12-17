using ASPExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPExample.ViewModels;

namespace ASPExample.Controllers
{
    public class ReviewsController : Controller
    {
        private ASPExampleContext db = new ASPExampleContext();

        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                ProductsListViewModel model = new ProductsListViewModel();
                model.Products = db.Products;
                model.Reviews = db.Reviews.Where(review => review.UserId == Convert.ToInt32(Session["UserId"])).ToList();

                return View(model);
            }

            return RedirectToAction("Index", "Products");
        }


        // GET: Reviews/Add
        public ActionResult Add()
        {
            if (Session["Username"] != null)
            {
                return View();
            }

            return RedirectToAction("Index", "Products");
        }

        // POST: Reviews/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int id, Review review, string previousPage)
        {
            if (ModelState.IsValid)
            {
                review.Author = Session["Username"].ToString();
                review.UserId = Convert.ToInt32(Session["UserId"]);
                review.ProductId = id;
                review.DateCreated = DateTime.Now;
                db.Reviews.Add(review);
                db.SaveChanges();
                if (previousPage != null)
                {
                    return Redirect(previousPage);
                }
                else
                {
                    return RedirectToAction("Details", "Products", new { id = id });
                }
            }

            return View(review);
        }

        // GET: Reviews/Edit/:id
        public ActionResult Edit(int id)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Products");
            }

            Review review = db.Reviews.Find(id);

            if (review == null || review.UserId != Convert.ToInt32(Session["UserId"]))
            {
                return RedirectToAction("Index", "Products");
            }

            return View(review);
        }

        // POST: Reviews/Edit/:id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Review review, string previousPage)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Reviews.FirstOrDefault(item => item.ReviewId == id);

                entity.Heading = review.Heading;
                entity.Body = review.Body;
                db.Reviews.Update(entity);
                db.SaveChanges();
                if (previousPage != null)
                {
                    return Redirect(previousPage);
                }
                else
                {
                    return RedirectToAction("Index", "Products");
                }
            }
            return View(review);
        }

        // GET: Reviews/Delete/:id
        public ActionResult Delete(int id)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Products");
            }

            Review review = db.Reviews.Find(id);

            if (review == null || review.UserId != Convert.ToInt32(Session["UserId"]))
            {
                return RedirectToAction("Index", "Products");
            }

            return View(review);
        }

        // POST: Reviews/Delete/:id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string previousPage)
        {
            if (ModelState.IsValid)
            {
                Review review = db.Reviews.Find(id);

                db.Reviews.Remove(review);
                db.SaveChanges();

                if (previousPage != null)
                {
                    return Redirect(previousPage);
                }
                else
                {
                    return RedirectToAction("Index", "Products");
                }
            }
            return View();
        }
    }
}