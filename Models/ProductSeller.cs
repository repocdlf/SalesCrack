using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.Models
{
    public class ProductSeller
    {
        public int IdProduct
        {
            get;
            set;
        }
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
        public ProductSeller(int idProduct, int idSeller, double price)
        {
            this.IdProduct = idProduct;
            this.IdSeller = idSeller;
            this.Price = price;
        }
    }
}