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
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            //int idSeller = 0;
            //List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(isSeller);
            return View("Products", lista);
        }

        public ActionResult Edit()
        {
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            //int idSeller = 0;
            //List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(isSeller);
            return View("Edit", lista);
        }
    }
}