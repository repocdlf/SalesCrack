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
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Products", lista);
        }

        public ActionResult Edit()
        {
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Edit", lista);
        }

        public ActionResult Load(string type)
        {
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
    }
}