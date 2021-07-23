using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DO_AN_APS_DOC_NET_MVC.ViewModels
{
    public class CartsViewModel
    {
        private ApplicationDbContext db;
        public CartsViewModel()
        {
            db = new ApplicationDbContext();
        }

        public IEnumerable<Cart> Carts { get; set; }

        public string GetProductName(int id_model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
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

    }
}