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
                    listChar.Add('.');
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