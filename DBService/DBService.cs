using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesCrack.DBService
{
    public class DBService
    {
        private List<Seller> Sellers { get; }
        private List<Product> Stock { get; set; }
        private List<Product> Sold { get; set; }

        private static DBService Instance = new DBService();

        private DBService()
        {
            this.Sellers = new List<Seller>();
            this.Stock = new List<Product>();
            this.Sold = new List<Product>();
        }

        public static DBService GetInstance()
        {
            return DBService.Instance;
        }

        /**
         * Agrega un vendedor a la base de vendedores. En caso de que el vendedor ya exista actualiza el password
         */
        public void AddSeller(Seller seller)
        {
            if (seller != null && seller.IdSeller > 0)
            {
                Seller s = FindSellerById(seller.IdSeller);
                if (s != null)
                {
                    s.ChangePassword(seller.Password);
                }
                else
                {
                    this.Sellers.Add(seller);
                }
            }
        }

        /**
         * Agrega el producto en la base de productos. En caso que ya este incrementa el stock
         */
        public void AddToStock(Product product)
        {
            //Si el producto ya existe solo debe incrementar el stock, primero se debe hacer una busqueda
            Product p = this.FindProductInStock(product.Code);
            if (p != null)
            {
                p.Stock += product.Stock;
            }
            else
            {
                this.Stock.Add(product);
            }
        }

        /**
         * Realiza la venta del producto a nivel de datos. Decrementa el stock del producto o lo elimina si correcponde
         */
        public void AddToSold(Product product)
        {
            //Buscar en el stock, decrementar, remover del stock si queda cero, agregar a la lista de vendidos
            Product p = this.FindProductInStock(product.Code);
            if (p != null)
            {
                p.Stock--;
                if (p.Stock == 0)
                {
                    this.Stock.Remove(product);
                }
            }
            this.Sold.Add(product);
        }

        /**
         * Busca un producto en el stock por el codigo
         */
        public Product FindProductInStock(int code)
        {
            Product p = null;
            int i = 0;
            while (p == null && i < this.Stock.Count)
            {
                Product aux = this.Stock.ElementAt(i);
                if (aux.Code == code)
                {
                    p = aux;
                }
                i++;
            }
            return p;
        }

        /**
         * Busca un vendedor en la base por el ID
         */
        public Seller FindSellerById(int idSeller)
        {
            Seller s = null;
            int i = 0;
            while (s == null && i < this.Sellers.Count)
            {
                Seller aux = this.Sellers.ElementAt(i);
                if (aux.IdSeller == idSeller)
                {
                    s = aux;
                }
                i++;
            }
            return s;
        }

        public List<Product> SearchProductsBySeller(int idSeller)
        {
            List<Product> products = new List<Product>();
            foreach (Product p in this.Stock)
            {
                if (p.Seller.IdSeller == idSeller)
                {
                    products.Add(p);
                }
            }
            return products;
        }

        public List<Product> SearchAllProducts()
        {
            List<Product> products = new List<Product>();
            foreach (Product p in this.Stock)
            {
                products.Add(p);
            }
            return products;
        }

        public Seller FindSellerByUsername(string username)
        {
            Seller s = null;
            int i = 0;
            while (s == null && i < this.Sellers.Count)
            {
                Seller aux = this.Sellers.ElementAt(i);
                if (aux.Usename == username)
                {
                    s = aux;
                }
                i++;
            }
            return s;
        }
    }
}