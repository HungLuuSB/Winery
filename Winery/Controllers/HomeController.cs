using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Winery.Models;

namespace Winery.Controllers
{
    public class HomeController : Controller
    {

        private WineryEntities2 db = new WineryEntities2();

        public ActionResult Index()
        {
            var products = db.Product.Include(p => p.Category).ToList();
            return View(products);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}