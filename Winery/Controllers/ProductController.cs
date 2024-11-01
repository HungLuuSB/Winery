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
    public class ProductController : Controller
    {
        private WineryEntities2 db = new WineryEntities2();

        public string GetSortOption()
        {
            if (Session["SortOption"] == null)
                Session["SortOption"] = "RELEVANCE";
            return Session["SortOption"].ToString();
        }
        // GET: Product
        [HttpGet]
        public ActionResult Index(int? style, string SortOption)
        {
            IQueryable<Product> product;
            string option;
            if (!string.IsNullOrEmpty(SortOption))
            {
                option = SortOption;
            }
            else
            {
                option = "RELEVANCE";
            }
            Session["SortOption"] = option;
            if (style != 0)
            {
                ViewBag.Category = CategoryUtilityService.GetCategoryByID(style.Value);
                product = db.Product.Where(p => p.Category.CategoryID == style)
                                        .Include(p => p.Category)
                                        .Include(p => p.Brand);
            }
            else
            {
                ViewBag.Category = null;
                product = db.Product.Include(p => p.Category)
                                    .Include(p => p.Brand);
                
            }
            ViewBag.Style = style;
            switch (option)
            {
                case "RELEVANCE":
                    break;
                case "PRICE-ASC":
                    product = product.OrderBy(p => p.ProductPrice);
                    break;
                case "PRICE-DESC":
                    product = product.OrderByDescending(p => p.ProductPrice);
                    break;
                case "NAME-ASC":
                    product = product.OrderBy(p => p.ProductName);
                    break;
                case "NAME-DESC":
                    product = product.OrderByDescending(p => p.ProductName);
                    break;
            }
            return View(product.ToList());
        }

        // GET: Product/Details/5
        /*
         public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        */
        public ActionResult Details(string productName)
        {
            if (productName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Where(x => x.ProductName == productName).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductCategoryID = new SelectList(db.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductDesc,ProductYearAging,ProductPrice,ProductCapacity,ProductOrigin,ProductCategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryID = new SelectList(db.Category, "CategoryId", "CategoryName", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryID = new SelectList(db.Category, "CategoryId", "CategoryName", product.ProductCategoryID);
            ViewBag.ProductBrandID = new SelectList(db.Brand, "BrandId", "BrandName", product.ProductBrandID);
            
            /*
            ViewBag.ProductBrandID = db.Brand.Select(b => new SelectListItem
            {
                Value = b.BrandId.ToString(),
                Text = b.BrandName
            }).ToList();
            */
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductDesc,ProductYearAging,ProductPrice,ProductCapacity,ProductOrigin,ProductCategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryID = new SelectList(db.Category, "CategoryId", "CategoryName", product.ProductCategoryID);
            ViewBag.ProductBrandID = new SelectList(db.Brand, "BrandID", "BrandName", product.ProductBrandID);
            /*
            ViewBag.ProductBrandID = db.Brand.Select(b => new SelectListItem
            {
                Value = b.BrandId.ToString(),
                Text = b.BrandName
            }).ToList();
            */
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
