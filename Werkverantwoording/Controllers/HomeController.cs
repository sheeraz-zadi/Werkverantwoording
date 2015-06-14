using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Werkverantwoording.DAL;
using Werkverantwoording.Models;

namespace Werkverantwoording.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext db = new TaskContext();
        public ActionResult Index()
        {   
            User currentUser;
            using (var ctx = new TaskContext())
            {
                currentUser = ctx.Users.Where(s => s.Email == User.Identity.Name).FirstOrDefault<User>();
            }

            if (currentUser != null) { 
            
            if (currentUser.Role.ToString() == "Teacher")
            {
                return RedirectToAction("Index", "User");
            }
            if (currentUser.Role.ToString() == "Student")
            {
                return View();
            }
            }

            return RedirectToAction("Login", "User");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}