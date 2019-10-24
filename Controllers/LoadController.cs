using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesCrack.Controllers
{
    public class LoadController : Controller
    {
        public ActionResult Upload(string type)
        {
            foreach (string file in Request.Files)
            {
                HttpFileCollectionBase hpf = Request.Files;
                if (hpf.Count > 0)
                {
                    StreamReader reader = new StreamReader(hpf[0].InputStream);
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] arr = line.Split(',');
                        if ("sellers" == type)
                        {
                            int idSeller = int.Parse(arr[0]);
                            string usename = arr[1];
                            string password = arr[2];
                            Seller seller = new Seller(idSeller, usename, password);
                            DBService.DBService.GetInstance().AddSeller(seller);
                        }
                        if ("products" == type)
                        {
                            int idProduct = int.Parse(arr[0]);
                            string name = arr[1];
                            int stock = int.TryParse(arr[2], out stock) ? int.Parse(arr[2]) : 1;
                            double price = double.Parse(arr[3], CultureInfo.InvariantCulture);
                            bool active = bool.Parse(arr[4]);
                            int idSeller = int.Parse(arr[5]);
                            Seller seller = DBService.DBService.GetInstance().FindSellerById(idSeller);
                            if (seller != null)
                            {
                                Product product = new Product(idProduct, name, stock, price, active, seller);
                                DBService.DBService.GetInstance().AddToStock(product);
                            }

                        }
                        line = reader.ReadLine();
                    }
                }
            }
            return RedirectToAction("Load", "Admin");
        }
    }
}