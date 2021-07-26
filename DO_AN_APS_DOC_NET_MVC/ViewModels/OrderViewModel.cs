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
        public IEnumerable<Order_Detail> Order_Details { get; set; }

        public string GetCustomerName(string customer_id)
        {
            var customerName = db.Users.FirstOrDefault(i => i.Id == customer_id);
            return customerName.Name.ToString();
        }

        public Order Order { get; set; }


        public string GetProductName(int id_model)
        {
            var product_model = db.Product_Models.Find(id_model);
            return product_model.Name;
        }

        public double GetProductPrice(int id_model)
        {
            var product_model = db.Product_Models.Find(id_model);
            return product_model.Price;
        }
        // Format Price
        public string FormatPrice(double price)
        {
            string strPrice = price.ToString();
            string result = "";
            List<char> listChar = new List<char>();
            int point = 1;
            for (int i = strPrice.Length - 1; i >= 0; i--)
            {
                if (point == 4)
                {
                    point = 1;
                    listChar.Add(',');
                }
                listChar.Add(strPrice[i]);
                point++;
            }
            for (int i = listChar.Count - 1; i >= 0; i--)
            {
                result += listChar[i];
            }
            return result;
        }
    }
}