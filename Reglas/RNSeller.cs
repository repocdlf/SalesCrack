using SalesCrack.Datos;
using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SalesCrack.Reglas
{
    public class RNSeller
    {
        public static SalesCrackContext context = new SalesCrackContext();

        public static List<Seller> Buscar()
        {
            return ADSeller.BuscarSellers();
        }
        public static List<Seller> BuscarSellers()
        {

            return context.Seller.ToList();
        }

        public static Seller AddSeller(Seller seller)
        {
            seller = context.Seller.Add(seller);
            context.SaveChanges();
            context.Entry(seller).GetDatabaseValues();
            return seller;
        }
        public static void AddSeller2(Seller seller)
        {
            Validar(seller);
            ADSeller.AddSeller(seller);
        }

        public static void UpdateSeller(Seller newSeller)
        {
            Seller sellerDB = context.Seller.Find(newSeller.IdSeller);
            
            if(sellerDB != null)
            {
                sellerDB.Usename = newSeller.Usename;
                sellerDB.Password = newSeller.Password;
            }

            context.SaveChanges();
        }

        private static void Validar(Seller seller)
        {
            int cantidad = ADSeller.CuantosHay(seller);
            if (cantidad > 0)
                throw new Exception("El vendedor ya esta en la base");
        }

        internal static Seller SearchSeller(int idSeller)
        {
            return context.Seller.Where(m => m.IdSeller == idSeller).FirstOrDefault();
        }

        internal static Seller FindSellerByUsername(string username)
        {
            return context.Seller
                    .Where(l => l.Usename == username)
                    .FirstOrDefault();
        }

        
    }
}