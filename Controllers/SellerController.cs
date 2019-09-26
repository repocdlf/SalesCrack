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
        // GET: Seller
        public ActionResult Index()
        {
            return View("Seller");
        }
        public ActionResult PaginaVendedor()
        {
            List<ProductSeller> lista = new List<ProductSeller>();
            for(int i = 0; i < 1000; i++)
            {

              ProductSeller ps= new ProductSeller();
                ps.ID = i;
                ps.NomProduct= "nombre";
                ps.Precio = 5.99f;
                ps.Stock = 100;
                ps.UserID = "pepe" +i+ 1;

                lista.Add(ps);

            }

            return View("Seller",lista);

        }
    }
}