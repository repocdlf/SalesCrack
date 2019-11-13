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
            return RedirectToAction("Logout", "Login");
        }
        public ActionResult Login (Credential credent)
        {
            if (credent.username == null || "".Equals(credent.username))
            {
                return RedirectToAction("Logout", "Login");
            }
            if (credent.username=="admin"&& credent.password=="1234")
            {
                DBService.DBService.GetInstance().AddCredential(credent);
                SessionManager.SetCurrentUser(credent);
                return RedirectToAction("Products", "Admin");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(credent.username);
            if (seller != null && seller.Password == credent.password)
            {
                DBService.DBService.GetInstance().AddCredential(credent);
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