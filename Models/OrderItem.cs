using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
    // Usado solamente para pasaje de datos entre la vista y el controller
    public class OrderItem
    {
        
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

        public OrderItem(int idProduct, int quantity)
        {
            this.IdProduct = idProduct;
            this.Quantity = quantity;
        }

        public OrderItem()
        {
        }

    }
}