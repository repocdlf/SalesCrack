using SalesCrack.Datos;
using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SalesCrack.Reglas
{

    public class RNProduct
    {
        public static SalesCrackContext context = new SalesCrackContext();

        public static List<Product> SearchAllProducts()
        {
            return context.Product.ToList();
        }

        public static void AddProduct(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
        }


        //private static void Validate(Product product)
        //{
        //    if (product.Price < 0)
        //    {
        //        throw new Exception("El precio no puede ser menor a cero");
        //    }
        //}

        public static Product FindProduct(int idProduct)
        {
            return context.Product.Find(idProduct);
        }

        public static void UpdateProduct(Product product)
        {
            context.Product.AddOrUpdate(product);
            context.SaveChanges();
        }

        //public static void Remove(Product product)
        //{
        //    context.Product.Remove(product);
        //}

        /**
         * Devuelve la lista de productos activos asignados al vendedor
         * El sistema permite hasta una sobreventa, el administrador podra
         * recargar el stock al ver en su bandeja los productos sobrevendidos
         */
        internal static List<Product> SearchProductsBySeller(int idSeller)
        {
            List < Product > aux = context.Product.Where(o => o.IdSeller == idSeller).ToList();
            List<Product> ret = new List<Product>();
            foreach (var p in aux)
            {
                if (p.Active && p.Stock > 0)
                {
                    ret.Add(p);
                }
            }
            return ret;
        }
    }
}