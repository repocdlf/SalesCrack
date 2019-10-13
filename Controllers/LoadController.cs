using System;
using System.Collections.Generic;
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
                        if ("sellers"== type)
                        {
                            string idVendedor = arr[0];
                            string usr = arr[1];
                            string pwd = arr[2];
                        }
                        if ("products" == type)
                        {
                            string idProducto = arr[0];
                            string nombreProd = arr[1];
                            string cantidad = arr[2];
                            string precio = arr[3];
                            string flagActivo = arr[4];
                            string idSeller = arr[5];
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            return RedirectToAction("Load", "Admin");
        }
    }
}