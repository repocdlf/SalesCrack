using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
    public class Seller
    {
        public int IdSeller { get; set; }
        public string Usename { get; set; }
        public string Password { get; set; }
        private List<Product> Products { get; }

        public Seller(int idSeller, string username, string password)
        {
            this.IdSeller = idSeller;
            this.Usename = username;
            this.Password = password;
            this.Products = new List<Product>();
        }

        public void AssignProducts(List<Product> products)
        {
            foreach (Product p in products)
            {
                this.Products.Add(p);
            }
        }

        public void ChangePassword(string newPassword)
        {
            this.Password = newPassword;
        }
    }
}