using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.DTO
{
    public class ProductDTO
    {
        public int Id_Product { get; set; }
        public int Id_Model { get; set; }
        public string Size_Product { get; set; }
        public string Color_Product { get; set; }
        public int Num { get; set; }
        public string Name_Product { get; set; }
        public string Image_Front { get; set; }
        public double Price_Product { get; set; }

    }
}