using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesCrack.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Products()
        {
            return View("Products");
        }

        public ActionResult Edit()
        {
            return View("Edit");
        }

        public ActionResult Load()
        {
            return View("Load");
        }
    }
}