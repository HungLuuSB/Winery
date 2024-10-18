using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winery.Models;

namespace Winery.Controllers
{
    public class AccessController : Controller
    {
        private WineryEntities2 db = new WineryEntities2();

        // GET: Access
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}