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
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(modelo.username);
            if (seller != null && seller.Password == modelo.password)
            {
                return RedirectToAction("Products", "Seller", seller);
            }
            return View();
        }
    }

    
}