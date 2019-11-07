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

        public static void AddProducts(Product product)
        {
            product.IdSeller = product.Seller.IdSeller;
            product.Seller = null;
            context.Product.Add(product);
            
            context.SaveChanges();
        }


        private static void Validate(Product product)
        {
            if (product.Price < 0)
            {
                throw new Exception("El precio no puede ser menor a cero");
            }
        }

        public static Product FindProduct(int idProduct)
        {
            return context.Product.Find(idProduct);
        }

        public static void UpdateProduct(Product product)
        {
            context.Product.AddOrUpdate(product);
        }

        public static void Remove(Product product)
        {
            context.Product.Remove(product);
        }

        internal static List<Product> SearchProductsBySeller(int idSeller)
        {
            return context.Product
                .Where(o => o.Seller.IdSeller == idSeller)
                .ToList();

        }
    }
}