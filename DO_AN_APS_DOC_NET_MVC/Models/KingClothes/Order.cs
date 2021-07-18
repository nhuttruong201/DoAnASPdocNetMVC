using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.Models.KingClothes
{
    public class Order
    {
        [Display(Name = "Số Lượng")]
        public int Num { get; set; }
        [Display(Name = "Ngày Đặt")]
        public string Date { get; set; }
        [Display(Name = "Lời Nhắn")]
        public string Message { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
        [Key]
        [Column(Order = 1)]
        public string Id_Customer { get; set; }
        public ApplicationUser Customer { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Id_Product { get; set; }
        public Product Product { get; set; }
    }
}