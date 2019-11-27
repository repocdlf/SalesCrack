using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesCrack.Models;

namespace SalesCrack.ModelView
{
    public class RankingModelView
    {
        public string NameSeller { get; set; }
        public string IdProduct { get; set; }
        public string CountOrders { get; set; }
        public string TotalAmount { get; set; }
    }
}