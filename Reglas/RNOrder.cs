using SalesCrack.Datos;
using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.Reglas
{
    public class RNOrder
    {
        public static SalesCrackContext context = new SalesCrackContext();

        public static Order AddOrder(int idSeller)
        {
            Order ret;
            ret = context.Order.Add(new Order(idSeller));
            context.SaveChanges();
            context.Entry(ret).GetDatabaseValues();
            return ret;
        }
    }
}