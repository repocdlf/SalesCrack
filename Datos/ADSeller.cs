using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


/*
 * No se usa mas este clase, esta como ejemplo para  una conexion ADO
 */ 
namespace SalesCrack.Datos
{
    public class ADSeller
    {
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=.\\App_Data\\DBSalesCrack.mdf;Integrated Security=True";
        public static List<Seller> BuscarSellers()
        {
            List<Seller> listTemp = new List<Seller>();
            string consulta = "select Id, Last_Name, First_Name from jugadores";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(consulta, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listTemp.Add(new Seller(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()));
                }
                reader.Close();
            }
            return listTemp;
        }
        internal static void AddSeller(Seller seller)
        {
            string consulta = "insert into jugadores " +
                "(Last_Name, First_Name ) values " +
                "(@Last_Name, @First_Name)";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@Usename", seller.Usename);
                command.Parameters.AddWithValue("@Password", seller.Password);
                connection.Open();
                var retorno = command.ExecuteScalar();
                connection.Close();
            }
        }
        internal static int CuantosHay(Seller seller)
        {
            string consulta = "select count(1) from jugadores " +
                "where Last_Name = @Last_Name" +
                "   and First_Name = @First_Name";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@Usename", seller.Usename);
                command.Parameters.AddWithValue("@Password", seller.Password);
                connection.Open();
                var retorno = command.ExecuteScalar();
                connection.Close();
                return int.Parse(retorno.ToString());
            }
        }
    }
}