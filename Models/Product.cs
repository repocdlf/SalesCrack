using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public Seller Seller { get; set; }

        public Product(int code, string name, int stock, double price, bool active, Seller seller)
        {
            this.IdProduct = code;
            this.Name = name;
            this.Stock = stock;
            this.Price = price;
            this.Active = active;
            this.Seller = seller;
        }

        public void SetNewSeller(Seller seller)
        {
            this.Seller = seller;
        }
    }
}