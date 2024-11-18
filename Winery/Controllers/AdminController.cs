using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Winery.Models;
using Winery.Services;

namespace Winery.Controllers
{
    public class AdminController : Controller
    {
        WineryEntities2 db = new WineryEntities2();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            var currentUser = Session["user"] as User;
            if (currentUser == null)
                return RedirectToAction("Index", "Action");
            if (!PermissionService.UserHasPermission(currentUser, 2))
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            ViewData["registeredUsers"] = db.User.Include(p => p.UserPermission).ToList();
            ViewData["products"] = db.Product.Include(p => p.Category)
                                             .Include(p => p.Inventory)
                                             .Include(p => p.Brand).ToList();
            ViewData["brands"] = db.Brand.Include(p => p.Product)
                                         .Include(p => p.Category).ToList();
            ViewData["orders"] = db.Order.Include(p => p.OrderDetails).ToList();
            return View();
        }
    }
}