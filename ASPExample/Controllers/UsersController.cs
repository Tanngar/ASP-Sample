using ASPExample.Models;
using ASPExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPExample.Controllers
{
    public class UsersController : Controller
    {


        private ASPExampleContext db = new ASPExampleContext();



        // GET: Login
        public ActionResult Login()
        {
            if (Session["Username"] != null)
            {
                return RedirectToAction("Index", "Products");
            }

            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var account = db.Users.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).ToList();
                if (account.Count() > 0)
                {
                    Session["UserId"] = account.Single().UserId;
                    Session["Username"] = user.Username.ToString();
                    return RedirectToAction("Index", "Products");
                }
            }
            ModelState.AddModelError("error", "Username or password is invalid.");
            return View(user);
        }

        // GET: Logout
        public ActionResult Logout()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Products");
            }

            Session.Clear();

            return RedirectToAction("Index", "Products");
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            if (Session["Username"] != null)
            {
                return RedirectToAction("Index", "Products");
            }

            return View();
        }

        // POST: Users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.RepeatPassword != model.User.Password)
                {
                    return View(model);
                }

                db.Users.Add(model.User);
                db.SaveChanges();

                return RedirectToAction("Index", "Products");
            }

            return View(model);
        }
    }
}
