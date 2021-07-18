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
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
        [Display(Name = "Màu")]
        public string Color { get; set; }
        public string Size { get; set; }
        [Display(Name = "Mô Tả")]
        public string Describe { get; set; }
        [Display(Name = "Giá")]
        public double Price { get; set; }
        [Display(Name = "Số Lượng")]
        public int Num { get; set; }

        public int Id_Category { get; set; }
        public Category Category { get; set; }

        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Bill_Detail> Bill_Details { get; set; }
    }
}