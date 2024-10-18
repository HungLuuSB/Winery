using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Winery.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }
    }
}