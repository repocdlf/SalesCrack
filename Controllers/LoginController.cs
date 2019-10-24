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
        public ActionResult Login (Credential credent)
        {
            if (credent.username=="admin"&& credent.password=="1234")
            {
                if (System.Web.HttpContext.Current.Cache["current_user"] == null)
                {
                    System.Web.HttpContext.Current.Cache["current_user"] = credent;
                }
                Session["current_user"] = credent;
                return RedirectToAction("Products", "Admin");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(credent.username);
            if (seller != null && seller.Password == credent.password)
            {
                if (System.Web.HttpContext.Current.Cache["current_user"] == null)
                {
                    System.Web.HttpContext.Current.Cache["current_user"] = credent;
                }
                Session["current_user"] = credent;
                return RedirectToAction("Products", "Seller", seller);
            }
            return View();
        }
        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Cache.Remove("current_user");
            return View("Login");
        }
    }

    
}