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
        public int IdOrder
        {
            get;
            set;
        }
        
        public int IdSeller
        {
            get;
            set;
        }
       
        public Order() { }

        public Order(int idSeller)
        {
            this.IdSeller = idSeller;
        }
    }
}