using SalesCrack.Datos;
using SalesCrack.Models;
using SalesCrack.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SalesCrack.Reglas
{
    public class RNRanking
    {
        public static SalesCrackContext context = new SalesCrackContext();

        /**
         * En caso que alguno de los parametros sea nulo o contenga valores invalidos 
         * el ranking sera por cantidad ordenado de forma ascendente.
         **/
        public static List<RankingModelView> GetRankingBySeller(String field, String order)
        {
            field = (field != null && (field == "quantity" || field == "price") ? field : "quantity");
            order = (order != null && (order == "ASC" || order == "DESC") ? order : "DESC");
            List<RankingModelView> result;
            result = ADRanking.GetBulkRankingBySeller(field, order);
            return result;
        }

    }
}