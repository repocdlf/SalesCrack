using SalesCrack.Models;
using SalesCrack.Utility;
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
            SessionManager.RemoveCurrentUser();
            return View("Login");
        }
        public ActionResult Login (Credential credent)
        {
            if (credent.username=="admin"&& credent.password=="1234")
            {
                SessionManager.SetCurrentUser(credent);
                return RedirectToAction("Products", "Admin");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(credent.username);
            if (seller != null && seller.Password == credent.password)
            {
                SessionManager.SetCurrentUser(credent);
                return RedirectToAction("Products", "Seller", seller);
            }
            return View();
        }
        public ActionResult Logout()
        {
            SessionManager.RemoveCurrentUser();
            return View("Login");
        }
    }
}