using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Werkverantwoording.DAL;
using Werkverantwoording.Models;

namespace Werkverantwoording.Controllers
{
    public class DayController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: Progress
        public ActionResult Index()
        {
            return View(db.Day.ToList());
        }

        // GET: Progress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Day.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // GET: Progress/Create
        public ActionResult Create()
        {

            var assignments = db.Assignment.ToList();
            var assignmentsDesc = new List<string>();
            var assignmentsID = new List<int>();

            for (int i = 0; i < assignments.Count(); i++)
            {

                string assingnmentDesc = assignments[i].Description.ToString();
                int assingnmentID = assignments[i].ID;

                assignmentsDesc.Add(assingnmentDesc);
                assignmentsID.Add(assingnmentID);

            }

            ViewBag.assignmentsDesc = assignmentsDesc;
            ViewBag.assignmentsID = assignmentsID;

            return View();
        }

        // POST: Progress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,TaskID,Completed")] Day day, List<int> selectedAssignment)
        {
            if (ModelState.IsValid)
            {
                //day.ProgressID = null;
                day.Submitted = DateTime.Now;
                db.Day.Add(day);
                db.SaveChanges();

                foreach (int assignment in selectedAssignment)
                {
                    Progress progress = new Progress();
                    progress.taskID = assignment;
                    progress.dayID = day.ID;
                    db.Progress.Add(progress);
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(day);
        }

        // GET: Progress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day progress = db.Day.Find(id);
            if (progress == null)
            {
                return HttpNotFound();
            }
            return View(progress);
        }

        // POST: Progress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,TaskID,Completed")] Day day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(day).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(day);
        }

        // GET: Progress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Day.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // POST: Progress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Day day = db.Day.Find(id);
            db.Day.Remove(day);
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
