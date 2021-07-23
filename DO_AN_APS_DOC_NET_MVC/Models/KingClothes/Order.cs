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
        [Key]
        public int Id_Order { get; set; }
        [Display(Name = "Số Lượng")]
        public int Num { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ngày Đặt")]
        public string Date { get; set; }
        [Display(Name = "Lời Nhắn")]
        public string Message { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
       
        public string Id_Customer { get; set; }
        public ApplicationUser Customer { get; set; }

        public bool IsCheck { get; set; }

        public int Id_Product { get; set; }
        public Product Product { get; set; }
    }
}