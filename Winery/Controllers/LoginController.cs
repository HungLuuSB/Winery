using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winery.Models;

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
                Session["username"] = user.Username.ToString();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}