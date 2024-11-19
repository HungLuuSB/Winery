using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
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
            ViewBag.Message = Server.MapPath("~/Content/images/wine/");
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

        public ActionResult CreateProduct()
        {
            ViewData["Brands"] = db.Brand.Include(x => x.Category).ToList();
            ViewData["Categories"] = db.Category.Include(x => x.Brand).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(string ProductName, string ProductDesc, int ProductYearAging, float ProductABV,
            float ProductPrice, int ProductCapacity, string ProductOrigin, int ProductCategoryID, int ProductBrandID, int ProductStock, HttpPostedFileBase ProductImage)
        {
            try
            {
                Product product = new Product();
                product.ProductName = ProductName;
                product.ProductDesc = ProductDesc;
                product.ProductYearAging = ProductYearAging;
                product.ProductABV = ProductABV;
                product.ProductPrice = ProductPrice;
                product.ProductCapacity = ProductCapacity;
                product.ProductOrigin = ProductOrigin;
                product.ProductCategoryID = ProductCategoryID;
                product.ProductBrandID = ProductBrandID;

                db.Product.Add(product);
                db.SaveChanges();

                Inventory inventory = new Inventory();
                inventory.ProductID = product.ProductID;
                inventory.Quantity = ProductStock;

                db.Inventory.Add(inventory);
                db.SaveChanges();

                if (ProductImage != null && ProductImage.ContentLength > 0)
                {
                    var fileName = ProductUtilityService.ParseItemNameIntoPNGFileName(ProductName);
                    var filePath = Path.Combine(Server.MapPath("~/Content/images/wine/"), fileName);
                    ProductImage.SaveAs(filePath);
                    ViewBag.Message = filePath;
                }
                
                return RedirectToAction("Dashboard", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
        }

        public ActionResult EditProduct(int id)
        {
            ViewData["Brands"] = db.Brand.Include(x => x.Category).ToList();
            ViewData["Categories"] = db.Category.Include(x => x.Brand).ToList();
            var product = db.Product.Find(id);
            if (product == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(int ProductID, string ProductName, string ProductDesc, int ProductYearAging, float ProductABV,
            float ProductPrice, int ProductCapacity, string ProductOrigin, int ProductCategoryID, int ProductBrandID, float ProductSalePrice, int ProductStock)
        {
            var product = db.Product.Find(ProductID);
            var inventory = product.Inventory;
            if (ModelState.IsValid)
            {
                product.ProductName = ProductName;
                product.ProductDesc = ProductDesc;
                product.ProductYearAging = ProductYearAging;
                product.ProductABV = ProductABV;
                product.ProductPrice = ProductPrice;
                product.ProductCapacity = ProductCapacity;
                product.ProductOrigin = ProductOrigin;
                product.ProductCategoryID = ProductCategoryID;
                product.ProductBrandID = ProductBrandID;

                if (product.ProductOnSale == false)
                {
                    if (ProductSalePrice != null && ProductSalePrice > 0)
                    {
                        product.ProductOnSale = true;
                        product.ProductPrice = ProductSalePrice;
                    }
                    else
                    {
                        product.ProductOnSale = false;
                    }
                }
                

                inventory.Quantity = ProductStock;

                db.Entry(product).State = EntityState.Modified;
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard", "Admin");
        }

        public ActionResult CreateBrand()
        {
            ViewData["Categories"] = db.Category.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateBrand(string BrandName, int BrandCategoryID)
        {
            var brand = new Brand();
            brand.BrandName = BrandName;
            brand.Category = db.Category.Where(x => x.CategoryID == BrandCategoryID).ToList();

            if (ModelState.IsValid)
            {
                db.Brand.Add(brand);
                db.SaveChanges();
            }

            return RedirectToAction("Dashboard", "Admin");
        }

        public ActionResult GetSalesChart()
        {
            var productSold = new List<Product>();
            foreach (var product in db.Product.ToList())
            {
                if (ProductUtilityService.GetProductPurchased(product.ProductID) > 0)
                    productSold.Add(product);
            }
            var productName = new List<string>();
            foreach (var product in productSold)
            {
                productName.Add(product.ProductName);
            }
            var productSale = new List<int>();
            foreach (var product in productSold)
            {
                productSale.Add(ProductUtilityService.GetProductPurchased(product.ProductID));
            }
            var chart = new Chart(700, 500)
                .AddTitle("Product sales")
                .AddSeries(
                    name: "Product",
                    xValue: productName,
                    yValues: productSale).GetBytes("png");
            return File(chart, "image/png");
        }
    }
}