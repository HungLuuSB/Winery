using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winery.Models;
using Winery.Services;
using Winery.Ultilities;

namespace Winery.Controllers
{
    public class LoginController : Controller
    {
        private WineryEntities2 db = new WineryEntities2();
        // GET: Login
        [HttpPost]
        public ActionResult Login(User User)
        {
            var user = db.User.Where(x => x.Email.Equals(User.Email) && x.Password.Equals(User.Password)).FirstOrDefault();
            if (user != null) {
                User _user = db.User.Find(user.UserID);
                UserSessionService.CurrentUser = _user;
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (UserSessionService.CurrentUser != null)
            {
                UserSessionService.CurrentUser = null;
                Session["user"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username,Password,Email,FirstName,LastName,MiddleName")] User user)
        {
            if (ModelState.IsValid)
            {
                var _validateEmail = db.User.Where(x => x.Email == user.Email).FirstOrDefault();
                if (_validateEmail != null) 
                {
                    return View();
                }

                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Access");
            }
            return View();
        }
    }
}