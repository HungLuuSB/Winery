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
    public class UserController : Controller
    {
        private WineryEntities2 db = new WineryEntities2();

        // GET: User
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            var currentUser = Session["user"] as User;
            if (currentUser != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    if (id == currentUser.UserID)
                    {
                        ViewData["Address"] = db.Address.FirstOrDefault(x => x.UserID == id);
                        User user = db.User.Find(id);
                        return View(user);
                    }
                    else
                    {
                        if (PermissionService.UserHasPermission(currentUser, 2))
                        {
                            User user = db.User.Find(id);
                            return View(user);
                        }
                        else
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                        }
                    }
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Email,Password,FirstName,LastName,MiddleName,DateOfBirth,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);

                db.SaveChanges();
                UserPermission permission = new UserPermission();
                permission.UserId = user.UserID;
                permission.PermissionId = 3;
                db.UserPermission.Add(permission);
                db.SaveChanges();
                return RedirectToAction("Index", "Access");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string LastName, string MiddleName, string FirstName)
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", "Access");
            var user = db.User.Find(UserSessionService.CurrentUser.UserID);
            if (ModelState.IsValid)
            {
                user.LastName = LastName;
                user.FirstName = FirstName;
                user.MiddleName = MiddleName;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "User", new {id = user.UserID });
            }
            return RedirectToAction("Details", "User", new { id = user.UserID });
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetUserActions(int id)
        {
            User user = db.User.Find(id);
            return PartialView("GetUserActions", user);
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
