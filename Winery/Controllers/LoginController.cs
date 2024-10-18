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
        public ActionResult Index()
        {
            return View();
        }
    }
}