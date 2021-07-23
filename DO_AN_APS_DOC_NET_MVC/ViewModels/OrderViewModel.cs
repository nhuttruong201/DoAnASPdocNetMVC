using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.ViewModels
{
    public class OrderViewModel
    {
        private ApplicationDbContext db;
        public OrderViewModel()
        {
            db = new ApplicationDbContext();
        }
        public IEnumerable<Order> Orders { get; set; }

        public string GetCustomerName(string customer_id)
        {
            var customerName = db.Users.FirstOrDefault(i => i.Id == customer_id);
            return customerName.Name.ToString();
        }


        public string GetProductName(int id_model)
        {
            var product_model = db.Product_Models.Find(id_model);
            return product_model.Name;
        }
    }
}