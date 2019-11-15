using SalesCrack.Models;
using SalesCrack.Utility;
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
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username == "admin")
            {
                return RedirectToAction("Logout", "Login");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(currentUser.username);
            List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(seller.IdSeller);
            return View("Products", lista);
        }

        public ActionResult Edit()
        {
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username == "admin")
            {
                return RedirectToAction("Logout", "Login");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(currentUser.username);
            List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(seller.IdSeller);
            return View("Edit", lista);
        }

        public ActionResult Sell(int idProduct)
        {
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username == "admin")
            {
                return RedirectToAction("Logout", "Login");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(currentUser.username);
            Product product = DBService.DBService.GetInstance().FindProductInStock(idProduct);
            if (product != null && product.IdSeller == seller.IdSeller)
            {
                DBService.DBService.GetInstance().DoSell(idProduct, seller.IdSeller);
            }
            List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(seller.IdSeller);
            return View("Edit", lista);
        }

        public ActionResult Order()
        {
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username == "admin")
            {
                return RedirectToAction("Logout", "Login");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(currentUser.username);

            List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(seller.IdSeller);
            return View("Order", lista);
        }

        public ActionResult BulkOrder(List<OrderItem> orderItems)
        {
            orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem(11, 3));
            orderItems.Add(new OrderItem(21, 3));
            orderItems.Add(new OrderItem(31, 3));
            orderItems.Add(new OrderItem(41, 3));
            orderItems.Add(new OrderItem(51, 3));
            orderItems.Add(new OrderItem(16, 3));
            orderItems.Add(new OrderItem(17, 3));
            orderItems.Add(new OrderItem(18, 3));
            orderItems.Add(new OrderItem(19, 3));
            orderItems.Add(new OrderItem(13, 3));
            Credential currentUser = SessionManager.GetCurrentUser();
            if (currentUser == null || currentUser.username == "admin")
            {
                return RedirectToAction("Logout", "Login");
            }
            Seller seller = DBService.DBService.GetInstance().FindSellerByUsername(currentUser.username);
            if (orderItems != null && orderItems.Any())
            {
                // Proceso de gravacion del pedido
                // Agregar registro en la tabla OrderSeller y obtener el IdOrder para este vendedor
                Order os = DBService.DBService.GetInstance().CreateOrder(seller.IdSeller);
                foreach (OrderItem item in orderItems)
                {
                    Product product = DBService.DBService.GetInstance().FindProductInStock(item.IdProduct);
                    if (product != null && product.IdSeller == seller.IdSeller)
                    {
                        // Agregar el detalle del pedido
                        DBService.DBService.GetInstance().AddOrderDetail(os.IdOrder, item.IdProduct, item.Quantity);
                        // Proceso de ejecucion de la venta por mayor
                        DBService.DBService.GetInstance().DoSell(item.IdProduct, seller.IdSeller, item.Quantity);
                    }
                }
            }
            List<Product> lista = DBService.DBService.GetInstance().SearchProductsBySeller(seller.IdSeller);
            return View("Order", lista);
        }
    }
}