using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
    public class Order
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public int IdProduct
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
        public double TotalPrice
        {
            get;
            set;
        }

        public Order() { }

        public Order(int idProduct, int quantity, double totalPrice)
        {
            this.IdProduct = idProduct;
            this.Quantity = quantity;
            this.TotalPrice = totalPrice;
        }
    }
}