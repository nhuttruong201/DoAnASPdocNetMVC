using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.Models.KingClothes
{
    public class Bill_Temp
    {
        [Key]
        public int Id_Bill_Temp { get; set; }
        public int Id_Product { get; set; }
        public int Num { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Image_Front { get; set; }
    }
}