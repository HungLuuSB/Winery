using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Winery.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
    }
}