using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
    public class OrderSeller
    {
        [Key]
        public int Id
        {
            get;
            set;
        }
       
        
        public int IdSeller
        {
            get;
            set;
        }
       
        public OrderSeller() { }

        public OrderSeller(int id, int idSeller)
        {
            this.Id = id;
            this.IdSeller = idSeller;
        }
    }
}