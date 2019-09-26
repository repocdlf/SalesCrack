using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesCrack.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Upload()
        {
            return View("Seller");
        }
    }
}