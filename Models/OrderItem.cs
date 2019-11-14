using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
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
        
    }
}