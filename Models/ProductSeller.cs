using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
    public class ProductSeller
    {
        public int ID
        {
            get;
            set;
        }
        public string NomProduct
        {
            get;
            set;
        }
        public string UserID
        {
            get;
            set;
        }
        public float Precio
        {
            get;
            set;
        }
        public int Stock
        {
            get;
            set;
        }
    }
}