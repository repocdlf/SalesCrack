using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SalesCrack.Models;

namespace SalesCrack.Datos
{
    public class SalesCrackContext : DbContext
    {
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="
            + AppDomain.CurrentDomain.BaseDirectory
            + "App_Data\\DBSalesCrack.mdf;Integrated Security=True";
        //public SalesCrackContext() : base("SalesCrackContext")
        public SalesCrackContext() : base(connectionString)
        {
            Database.SetInitializer<SalesCrackContext>(new SalesCrackInitializer());
        }

        public DbSet<Seller> Seller { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductSeller> ProductSeller { get; set; }
        public DbSet<Credential> Credential { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Order { get; set; }

    }

    public class SalesCrackInitializer : DropCreateDatabaseIfModelChanges<SalesCrackContext>
    {
        protected override void Seed(SalesCrackContext context)
        {
            base.Seed(context);
            //context.Seller.Add(new Seller(1, "gperez", "gperez"));
            //context.Seller.Add(new Seller(2, "dgomez", "dgomez"));
            //context.Seller.Add(new Seller(3, "cruiz", "cruiz"));
            //context.SaveChanges();
        }
    }
}