using SalesCrack.Datos;
using SalesCrack.Models;
using System;
using System.Collections.Generic;
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

        public static void AddSeller(Seller seller)
        {
            //Validar(seller);
            context.Seller.Add(seller);
            context.SaveChanges();

        }
        public static void AddSeller2(Seller seller)
        {
            Validar(seller);
            ADSeller.AddSeller(seller);
        }

        private static void Validar(Seller seller)
        {
            int cantidad = ADSeller.CuantosHay(seller);
            if (cantidad > 0)
                throw new Exception("El vendedor ya esta en la base");
        }
    }
}