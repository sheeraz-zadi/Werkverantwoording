using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Werkverantwoording.DAL;
using Werkverantwoording.Models;

namespace Werkverantwoording.Controllers
{
    public class TeacherController : Controller
    {
        public TaskContext db = new TaskContext();
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Confirmation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirmation(Day day, int? id)
        {
            
            var test = db.Days.Where(u => u.ID == id).FirstOrDefault();
            test.Completed = true;
            db.SaveChanges();

            return RedirectToAction("Index", "Day");
        }
    }
}