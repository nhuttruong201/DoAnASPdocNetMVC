using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.ViewModels
{
    public class ProductsViewModel
    {
        public string strSearch { get; set; }
        public Product ProductDetail { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string Heading { get; set; }

        public IEnumerable<Product> Tees { get; set; }
        public IEnumerable<Product> Pants { get; set; }
        public IEnumerable<Product> Denims { get; set; }
        public IEnumerable<Product> Bags { get; set; }
    }
}