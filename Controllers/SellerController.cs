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
            return View("Products");
        }

        public ActionResult Edit()
        {
            return View("Edit");
        }
        public ActionResult PaginaVendedor()
        {
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Seller", lista);
        }
    }
}