using SalesCrack.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesCrack.Controllers
{
    public class SellerController : Controller
    {
        public ActionResult Products()
        {
            Credential currentUser = (Credential)System.Web.HttpContext.Current.Cache["current_user"];
            if (currentUser == null || currentUser.username == "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(currentUser.username);
            List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(seller.IdSeller);
            return View("Products", lista);
        }

        public ActionResult Edit()
        {
            Credential currentUser = (Credential)System.Web.HttpContext.Current.Cache["current_user"];
            if (currentUser == null || currentUser.username == "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(currentUser.username);
            List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(seller.IdSeller);
            return View("Edit", lista);
        }

        public ActionResult Sell(int idProduct)
        {
            Credential currentUser = (Credential)System.Web.HttpContext.Current.Cache["current_user"];
            if (currentUser == null || currentUser.username == "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            Product product = DBService.DBService.GetInstance().FindProductInStock(idProduct);

            Seller seller = DBService.DBService.GetInstance().FindSellerById(product.Seller.IdSeller);
            DBService.DBService.GetInstance().DoSell(idProduct, seller.IdSeller);
            List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(seller.IdSeller);
            return View("Edit", lista);
        }


    }
}