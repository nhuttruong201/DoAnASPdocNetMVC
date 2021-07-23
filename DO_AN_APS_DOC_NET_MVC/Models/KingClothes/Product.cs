using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.Models.KingClothes
{
    public class Product
    {
        [Key]
        public int Id_Product { get; set; }

        [Display(Name = "Ảnh Mặt Trước")]
        public string Image_Front { get; set; }

        [Display(Name = "Ảnh Mặt Sau")]
        public string Image_Back { get; set; }

        [Display(Name = "Màu")]
        public string Color { get; set; }

        //[Display(Name = "Kích Cỡ")]
        public string Size { get; set; }

        [Display(Name = "Số Lượng")]
        public int Num { get; set; }

        // Quan hệ khóa ngoại
        public int Id_Category { get; set; }
        public Category Category { get; set; }

        public int Id_Model { get; set; }
        public Product_Model Product_Model { get; set; }


        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Bill_Detail> Bill_Details { get; set; }
    }
}