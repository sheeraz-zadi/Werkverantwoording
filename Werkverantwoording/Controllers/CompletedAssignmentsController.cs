using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Werkverantwoording.DAL;
using Werkverantwoording.Models;

namespace Werkverantwoording.Controllers
{
    public class CompletedAssignmentsController : Controller
    {
         //
        // GET: /CompletedAssignments/
        public ActionResult Index()
        {
            return View();
        }

       

	}
}