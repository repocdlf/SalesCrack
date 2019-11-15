using SalesCrack.Datos;
using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.Reglas
{
    public class RNOrderDetail
    {
        public static SalesCrackContext context = new SalesCrackContext();

        public static OrderDetail AddOrderDetail(OrderDetail entity)
        {
            OrderDetail ret;
            ret = context.OrderDetail.Add(entity);
            context.SaveChanges();
            context.Entry(ret).GetDatabaseValues();
            return ret;
        }
    }
}