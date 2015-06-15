using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Werkverantwoording.DAL;

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
    }
}