using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
    public class ProductSeller
    {
        [Key]
        public int Id
        {
            get;
            set;
        }
        //[Key]
        //[Column(Order = 1)]
        public int IdProduct
        {
            get;
            set;
        }
        //[Key]
        //[Column(Order = 2)]
        public int IdSeller
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }

        public ProductSeller() { }

        public ProductSeller(int idProduct, int idSeller, double price)
        {
            this.IdProduct = idProduct;
            this.IdSeller = idSeller;
            this.Price = price;
        }
    }
}