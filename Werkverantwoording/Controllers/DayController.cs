﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Werkverantwoording.DAL;
using Werkverantwoording.Models;

namespace Werkverantwoording.Controllers
{
    [Authorize]
    public class DayController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: Progress
        public ActionResult Index()
        {
            return View(db.Days.ToList());
        }

        // GET: Progress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // GET: Progress/Create
        public ActionResult Create()
        {
            ViewBag.Assignments = db.Assignments;
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
                db.Days.Add(day);
                db.SaveChanges();

                foreach (int assignment in selectedAssignment)
                {
                    Progress progress = new Progress();
                    progress.taskID = assignment;
                    progress.dayID = day.ID;
                    db.Progresses.Add(progress);
                }

                db.SaveChanges();

                //Send mail to teacher with assignments

                //On localhost
                MailMessage mail = new MailMessage("dannybrouwertest@hotmail.com", "dannybrouwertest@mailinator.com");
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "localhost";
                NetworkCredential nc = new NetworkCredential("dannybrouwertest@hotmail.com", "Testmail1");
                client.Credentials = nc;
                mail.Subject = "Subject";
                mail.Body = "Body";
                mail.To.Add("dannybrouwertest@mailinator.com");

                client.Send(mail);

                //Anywhere else but localhost

                //string fromaddr = "dannybrouwertest@hotmail.com";
                //string toaddr = "dannybrouwer@msn.com"; 
                //string password = "Testmail1";


                //MailMessage msg = new MailMessage();
                //msg.Subject = "Onderwerp";
                //msg.From = new MailAddress(fromaddr);
                //msg.Body = "Body";
                //msg.To.Add(new MailAddress("dannybrouwer@msn.com"));
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "localhost";
                //smtp.Port = 25;
                //smtp.UseDefaultCredentials = false;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.EnableSsl = true;
                //NetworkCredential nc = new NetworkCredential(fromaddr, password);
                //smtp.Credentials = nc;
                //smtp.Send(msg);

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
            Day progress = db.Days.Find(id);
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
            Day day = db.Days.Find(id);
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
            Day day = db.Days.Find(id);
            db.Days.Remove(day);
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
