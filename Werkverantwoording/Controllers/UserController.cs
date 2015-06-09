using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Werkverantwoording.DAL;
using Werkverantwoording.Models;

namespace Werkverantwoording.Controllers
{
    public class UserController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: User
        public ActionResult Index()
        {
            var user = new User();
            string userMail = User.Identity.Name;

            User currentUser;
            //1. Get student from DB
            using (var ctx = new TaskContext())
            {
                currentUser = ctx.Users.Where(s => s.Email == userMail).FirstOrDefault<User>();
            }



            if (currentUser.Role.ToString() == "Student")
            {
                ViewBag.Student = "Hallo, student!";
            }

            if (currentUser.Role.ToString() == "Teacher")
            {
                ViewBag.Teacher = "Hallo, teacher!";
            }

            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (TaskContext dc = new TaskContext())
                {
                    var v = dc.Users.Where(a => a.Email.Equals(u.Email) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {

                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, u.Email
),
                        new Claim(ClaimTypes.Email, "user")
                        },
                        "ApplicationCookie");

                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;
                        authManager.SignIn(identity);

                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View();
        }

        public ActionResult AfterLogin()
        {
            if (Session["LoggedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        // GET: User/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
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
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
