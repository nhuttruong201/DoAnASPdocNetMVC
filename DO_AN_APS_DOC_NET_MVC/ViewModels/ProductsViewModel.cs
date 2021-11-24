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

        public List<string> GetSize(int id_product)
        {
            List<string> listSize = new List<string>();

            var products = db.Products.ToList();
            
            var productGetSize = db.Products.Find(id_product);

            foreach(Product item in products)
            {
                if(productGetSize.Id_Model == item.Id_Model && productGetSize.Color.Equals(item.Color))
                {
                    listSize.Add(item.Size);
                }
            }
            // sắp xếp size S M L XL
            int i, j;
            int l = listSize.Count();
            for (i = 0; i < l; i++)
            {
                for (j = 0; j < l - 1; j++)
                {
                    if (listSize[j].CompareTo(listSize[j + 1]) < 0)
                    {
                        var temp = listSize[j];
                        listSize[j] = listSize[j + 1];
                        listSize[j + 1] = temp;
                    }
                }
            }
            return listSize;
        }

        //
        public string Name { get; set; }
        public double price { get; set; }

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