using SalesCrack.Models;
using SalesCrack.ModelView;
using SalesCrack.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.DBService
{
    public class DBService
    {
        //private List<Seller> Sellers { get; set; }
        //private List<Product> Stock { get; set; }
        //private List<ProductSeller> Sold { get; set; }

        private static DBService Instance = new DBService();

        private DBService()
        {
            //this.Sellers = new List<Seller>();
            //this.Stock = new List<Product>();
            //this.Sold = new List<ProductSeller>();
        }

        internal void AddCredential(Credential credent)
        {
            RNCredential.AddCredential(credent);
        }

        public static DBService GetInstance()
        {
            return DBService.Instance;
        }

        /**
         * Agrega un vendedor a la base de vendedores. En caso de que el vendedor ya exista actualiza el password
         */
        public void AddSeller(Seller newSeller)
        {
            if (newSeller != null && newSeller.IdSeller > 0)
            {
                Seller existingSeller = FindSellerById(newSeller.IdSeller);
                if (existingSeller != null)
                {
                    //existingSeller.ChangePassword(newSeller.Password);
                    RNSeller.UpdateSeller(newSeller);
                }
                else
                {
                    //this.Sellers.Add(newSeller);
                    RNSeller.AddSeller(newSeller);
                }
            }
        }

        /**
         * Agrega el producto en la base de productos. En caso que ya este incrementa el stock
         */
        public void AddToStock(Product newProduct)
        {
            //Si el producto ya existe solo debe incrementar el stock y actualizar los datos del producto.
            //Primero se debe hacer una busqueda para validar si el producto ya existe en la base
            Product existingProduct = this.FindProductInStock(newProduct.IdProduct);
            if (existingProduct != null)
            {
                existingProduct.Name = newProduct.Name;
                existingProduct.Stock += newProduct.Stock;
                existingProduct.Price = newProduct.Price;
                existingProduct.Active = newProduct.Active;
                existingProduct.IdSeller = newProduct.IdSeller;
                //existingProduct.Seller = DBService.GetInstance().FindSellerById(newProduct.Seller.IdSeller);
                //existingProduct.Seller = RNSeller.SearchSeller(newProduct.Seller.IdSeller);
                RNProduct.UpdateProduct(existingProduct);
            }
            else
            {
                // this.Stock.Add(newProduct);
                RNProduct.AddProduct(newProduct);
               
            }
        }

        /*
           Cambia el estado del producto a Activado o Desactivado 
        */
        internal void ChangeProductStatus(Product product)
        {
            product.Active = !product.Active;
            RNProduct.UpdateProduct(product);
        }

        /**
         * Realiza la venta del producto a nivel de datos. Decrementa el stock del producto o lo elimina si correcponde
         */
        public void DoSell(int idProduct, int idSeller)
        {
            //Buscar en el stock, decrementar, remover del stock si queda cero, agregar a la lista de vendidos
            Product p = this.FindProductInStock(idProduct);
            Seller s = this.FindSellerById(idSeller);
            if (p != null && s != null)
            {
                p.Stock--;
                if (p.Stock < 0)
                {
                    //this.Stock.Remove(p);
                    //RNProduct.Remove(p);
                }
                else
                {
                    RNProduct.UpdateProduct(p);
                    ProductSeller ps = new ProductSeller(idProduct, idSeller, p.Price);
                    //this.Sold.Add(ps);
                    RNProductSeller.AddProductSeller(ps);
                }
                
            }
        }

        internal void AddOrderDetail(int idOrder, int idProduct, int quantity)
        {
            Product product = DBService.GetInstance().FindProductInStock(idProduct);
            OrderDetail order = new OrderDetail(idOrder, idProduct, quantity, product.Price * quantity);
            RNOrderDetail.AddOrderDetail(order);
        }

        public void DoSell(int idProduct, int idSeller, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                DBService.GetInstance().DoSell(idProduct, idSeller);
            }
        }

        public Order CreateOrder(int idSeller)
        {
            Order os;
            os = RNOrder.AddOrder(idSeller);
            return os;
        }

        /**
         * Busca un producto en el stock por el codigo
         */
        public Product FindProductInStock(int idProduct)
        {
            //Product product = null;
            //int i = 0;
            //while (product == null && i < this.Stock.Count)
            //{
            //    Product aux = this.Stock.ElementAt(i);
            //    if (aux.IdProduct == idProduct)
            //    {
            //        product = aux;
            //    }
            //    i++;
            //}
            return RNProduct.FindProduct(idProduct);
        }

        /**
         * Busca un vendedor en la base por el ID
         */
        public Seller FindSellerById(int idSeller)
        {
            //Seller s = null;
            //int i = 0;
            //while (s == null && i < this.Sellers.Count)
            //{
            //    Seller aux = this.Sellers.ElementAt(i);
            //    if (aux.IdSeller == idSeller)
            //    {
            //        s = aux;
            //    }
            //    i++;
            //}
            return RNSeller.SearchSeller(idSeller);
        }

        public List<Product> SearchProductsBySeller(int idSeller)
        {
            //List<Product> products = new List<Product>();
            //foreach (Product p in this.Stock)
            //{
            //    if (p.Seller.IdSeller == idSeller && p.Active)
            //    {
            //        products.Add(p);
            //    }
            //}
  
            return RNProduct.SearchProductsBySeller(idSeller);
        }

        public List<Product> SearchAllProducts()
        {
            //List<Product> products = new List<Product>();
            //foreach (Product p in this.Stock)
            //{
            //    products.Add(p);
            //}
            return RNProduct.SearchAllProducts();
        }

        public Seller FindSellerByUsername(string username)
        {
            //Seller s = null;
            //int i = 0;
            //while (s == null && i < this.Sellers.Count)
            //{
            //    Seller aux = this.Sellers.ElementAt(i);
            //    if (aux.Usename == username)
            //    {
            //        s = aux;
            //    }
            //    i++;
            //}
            return RNSeller.FindSellerByUsername(username);
        }

        /**
        * Devuelve una lista con todos los vendedores
        */
        public List<Seller> SearchAllSellers()
        {
            //List<Seller> Sellers = new List<Seller>();
            //foreach (Seller s in this.Sellers)
            //{
            //    Sellers.Add(s);
            //}
            return RNSeller.BuscarSellers();
        }

        public List<RankingModelView> GetRankingBySeller(String field, String order)
        {
            return RNRanking.GetRankingBySeller(field, order);
        }
    }
}