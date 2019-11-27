using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SalesCrack.ModelView;

namespace SalesCrack.Datos
{
    /**
     * Implementacion del ranking con ADO Net
     */
    public class ADRanking
    {
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="
            + AppDomain.CurrentDomain.BaseDirectory
            + "App_Data\\DBSalesCrack.mdf;Integrated Security=True";

        /**
         * Ranking por vendedor por pedido masivo hecho
         */
        public static List<RankingModelView> GetBulkRankingBySeller(String field, String order)
        {
            field = ("quantity".Equals(field) ? "CountOrders" : "TotalAmount");
            List<RankingModelView> listTemp = new List<RankingModelView>();
            string sql = "select s.Usename, count(od.Id) as CountOrders, sum(od.TotalPrice) as TotalAmount ";
            sql += "from Sellers as s  ";
            sql += "inner join Orders as o on (s.IdSeller = o.IdSeller) ";
            sql += "inner join OrderDetails as od on (o.IdOrder = od.IdOrder) ";
            sql += "group by s.Usename  ";
            sql += "order by " + field + " " + order;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RankingModelView itemRanking = new RankingModelView();
                    itemRanking.NameSeller = reader[0].ToString();
                    itemRanking.CountOrders = reader[1].ToString();
                    itemRanking.TotalAmount = reader[2].ToString();
                    listTemp.Add(itemRanking);
                }
                reader.Close();
                connection.Close();
            }
            return listTemp;
        }
    }
}