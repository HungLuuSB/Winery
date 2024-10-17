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

        private List<T> GetRandomItems<T>(List<T> items, int count)
        {
            return items.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
        }

        public ActionResult Index()
        {
            var products = db.Product.Include(p => p.Category).ToList();

            // Select 5 random products
            var randomProducts = GetRandomItems(products, 5);

            // Pass to the view
            return View(randomProducts);
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