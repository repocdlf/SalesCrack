using SalesCrack.Models;
using SalesCrack.ModelView;
using SalesCrack.Utility;
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
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username != "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Products", lista);
        }

        public ActionResult Edit()
        {
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username != "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Edit", lista);
        }

        public ActionResult Load(string view)
        {
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username != "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            if ("Sellers" == view)
            {
                ViewBag.id = view;
                ViewBag.name = view;
                ViewBag.label = "Sellers";
            }
            else if ("Products" == view)
            {
                ViewBag.id = view;
                ViewBag.name = view;
                ViewBag.label = "Products";
            }
            else
            {
                ViewBag.id = "Sellers";
                ViewBag.name = "Sellers";
                ViewBag.label = "Sellers";
            }
            List<Product> lista = DBService.DBService.GetInstance().SearchAllProducts();
            return View("Load", lista);
        }

        //Cambia el estado de un producto a Activado o Desactivado
        public void DoChangeProductStatus(int idProduct)
        {
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser != null && currentUser.username == "admin")
            {
                Product product = DBService.DBService.GetInstance().FindProductInStock(idProduct);
                product.Active = !product.Active;
            }
        }
        public ActionResult Sellers()
        {
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username != "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            List<Seller> lista = DBService.DBService.GetInstance().SearchAllSellers();
            return View("Sellers", lista);
        }

        /**
         * Ranking de pedidos por vendedor, cantidad de pedidos bulk, y monto acumulado de dichos pedidos
         * field = campo por el cual se debe ordenar el resultado, puede ser quantity | price
         * order = indica el tipo de ordenamiento, puede ser ASC | DESC
         **/
        public ActionResult RankingBulkOrders(String field, String order)
        {
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username != "admin")
            {
                return RedirectToAction("Login", "Login");
            }
            ViewBag.LastField = (field != null && (field == "quantity" || field == "price") ? field : "quantity");
            ViewBag.LastOrder = (order != null && (order == "ASC" || order == "DESC") ? order : "DESC");
            List<RankingModelView> lista = DBService.DBService.GetInstance().GetRankingBySeller(field, order);
            return View("RankingBulkOrders", lista);
        }
    }
}



