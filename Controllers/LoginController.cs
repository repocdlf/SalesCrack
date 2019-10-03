using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesCrack.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login (Credential modelo)
        {
            if (modelo.username=="admin"&&modelo.password=="1234")
            {
              return RedirectToAction("Products", "Admin");
            }
            if (modelo.username == "seller" && modelo.password == "1234")
            {
                return RedirectToAction("Products", "Seller");
            }
            return View();
        }
    }

    
}