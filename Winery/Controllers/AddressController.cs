﻿using System;
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
    public class AddressController : Controller
    {
        private WineryEntities2 db = new WineryEntities2();

        // GET: Address
        public ActionResult Index()
        {
            var currentUser = Session["user"] as User;
            if (currentUser == null)
                return RedirectToAction("Index", "Access");
            var address = db.Address.FirstOrDefault(x => x.UserID == currentUser.UserID);
            return View(address);
        }

        // GET: Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.User, "UserID", "Email");
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string AddressCity, string AddressProvince, string Address1)
        {
            var user = Session["user"] as User;
            if (user == null)
                return RedirectToAction("Index", "Access");
            if (ModelState.IsValid)
            {
                
                Address address = new Address();
                address.AddressCity = AddressCity;
                address.AddressProvince = AddressProvince;
                address.Address1 = Address1;
                address.UserID = db.User.Find(user.UserID).UserID;
                db.Address.Add(address);
                db.SaveChanges();
            }
            return RedirectToAction("Details", "User", new { id = UserSessionService.CurrentUser.UserID });
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.User, "UserID", "Email", address.UserID);
            return View(address);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string AddressCity, string AddressProvince, string Address1)
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", "Access");
            var user = Session["user"] as User;
            var address = db.Address.Where(x => x.UserID == user.UserID).First();
            
            if (ModelState.IsValid)
            {
                address.AddressCity = AddressCity;
                address.AddressProvince = AddressProvince;
                address.Address1 = Address1;
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
            }
            
            return RedirectToAction("Details", "User", new { id = user.UserID });
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Address.Find(id);
            db.Address.Remove(address);
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
