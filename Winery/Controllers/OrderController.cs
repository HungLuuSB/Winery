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
    public class OrderController : Controller
    {
        private WineryEntities2 db = new WineryEntities2();

        // GET: Order
        public ActionResult Index()
        {
            var currentUser = Session["user"] as User;
            if (currentUser == null)
                return RedirectToAction("Index", "Access");

            var order = db.Order.Where(x => x.UserID == currentUser.UserID).ToList();
            return View(order.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.User, "UserID", "Email");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "OrderID,OdrderDate,UserID,Total,City,Province,Address")] Order order)
        {
            if (ModelState.IsValid)
            {
                Cart cart = Session["Cart"] as Cart;
                if(UserSessionService.IsUserLoggedIn())
                    order.UserID = UserSessionService.CurrentUser.UserID;
                order.OdrderDate = DateTime.Now;
                order.Total = float.Parse(cart.TotalMoney().ToString());
                db.Order.Add(order);
                db.SaveChanges();
                int orderID = order.OrderID;
                foreach (var item in cart.Items)
                {
                    CreateOrderDetails(orderID, item);
                    db.SaveChanges();
                }
                cart.ClearCart();
                return RedirectToAction("Index");
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public void CreateOrderDetails(int orderID, CartItem item)
        {
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.OrderID = orderID;
            orderDetails.ProductID = item.Product.ProductID;
            orderDetails.Quantity = item.Quantity;
            orderDetails.UnitPrice = item.Product.ProductOnSale ? item.Product.ProductSalePrice.Value : item.Product.ProductPrice;
            db.OrderDetails.Add(orderDetails);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.User, "UserID", "Email", order.UserID);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OdrderDate,UserID,Total,City,Province,Address")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.User, "UserID", "Email", order.UserID);
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
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
