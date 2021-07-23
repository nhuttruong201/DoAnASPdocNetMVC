using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.ViewModels
{
    public class ProductsViewModel
    {
        private ApplicationDbContext db;
        public ProductsViewModel()
        {
            db = new ApplicationDbContext();
        }

        // load category
        public IEnumerable<Category> Categories { get; set; }

        public string strSearch { get; set; }
        public Product ProductDetail { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string Heading { get; set; }

        public IEnumerable<Product> Tees { get; set; }
        public IEnumerable<Product> Pants { get; set; }
        public IEnumerable<Product> Denims { get; set; }
        public IEnumerable<Product> Bags { get; set; }

        public string GetProductName(int id_model)
        {
            Product_Model product_Model = db.Product_Models.Find(id_model);
            return product_Model.Name;
        }

        public double GetProductPrice(int id_model)
        {
            Product_Model product_Model = db.Product_Models.Find(id_model);
            return product_Model.Price;
        }

        public string GetProductDescribe(int id_model)
        {
            Product_Model product_Model = db.Product_Models.Find(id_model);
            return product_Model.Describe;
        }

        //
        public string Name { get; set; }
        public double price { get; set; }
    }
}