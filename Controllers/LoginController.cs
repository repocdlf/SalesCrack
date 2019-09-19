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
        public ActionResult Login(string usuario, string password)
        {
            if (usuario == "Pablo" && password == "1234")
            {
                return View("Admin");
            }
            return View();
        }
    }

    
}