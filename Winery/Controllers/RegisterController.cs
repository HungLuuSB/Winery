using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winery.Models;
using Winery.Services;

namespace Winery.Controllers
{
    public class RegisterController : Controller
    {
        private WineryEntities2 db = new WineryEntities2();
        // GET: Register
        [HttpPost]
        public ActionResult Register(User User)
        {
            var user = db.User.Where(x => x.Email.Equals(User.Email) && x.Password.Equals(User.Password)).FirstOrDefault();
            if (user != null)
            {
                User _user = db.User.Find(user.UserID);
                UserSessionService.CurrentUser = _user;
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}