﻿using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winery.Models;
using Winery.Services;

namespace Winery.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        public ActionResult Register()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}