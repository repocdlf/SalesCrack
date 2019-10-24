using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SalesCrack.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Products()
        {
            Credential currentUser = (Credential)System.Web.HttpContext.Current.Cache["current_user"];
            if (currentUser == null || currentUser.username != "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Products", lista);
        }

        public ActionResult Edit()
        {
            Credential currentUser = (Credential)System.Web.HttpContext.Current.Cache["current_user"];
            if (currentUser == null || currentUser.username != "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Edit", lista);
        }

        public ActionResult Load(string type)
        {
            Credential currentUser = (Credential)System.Web.HttpContext.Current.Cache["current_user"];
            if (currentUser == null || currentUser.username != "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            if ("sellers" == type)
            {
                ViewBag.id = type;
                ViewBag.name = type;
                ViewBag.label = "Sellers";
            }
            else if ("products" == type)
            {
                ViewBag.id = type;
                ViewBag.name = type;
                ViewBag.label = "Products";
            }
            else
            {
                ViewBag.id = "sellers";
                ViewBag.name = "sellers";
                ViewBag.label = "Sellers";
            }
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Load", lista);
        }

        //Cambia el estado de un producto a Activado o Desactivado
        public void DoChangeProductStatus(int idProduct)
        {

            Product product = DBService.DBService.GetInstance().FindProductInStock(idProduct);

            product.Active = !product.Active;

        }
    }
}