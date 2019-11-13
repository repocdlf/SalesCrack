using SalesCrack.Datos;
using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.Reglas
{
    public class RNProductSeller

    {
        public static SalesCrackContext context = new SalesCrackContext();

        public static void AddProductSeller(ProductSeller ps)
        {
            context.ProductSeller.Add(ps);
            context.SaveChanges();
        }
    }
}