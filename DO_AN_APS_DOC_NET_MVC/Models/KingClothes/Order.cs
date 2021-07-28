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

        [Display(Name = "Số Điện Thoại")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ngày Đặt")]
        [Required]
        public DateTime Date { get; set; }
        [Display(Name = "Lời Nhắn")]
        public string Message { get; set; }
        [Display(Name = "Địa Chỉ")]
        [Required]
        public string Address { get; set; }
       
        public string Id_Customer { get; set; }
        public ApplicationUser Customer { get; set; }

        public bool IsCheck { get; set; }


        public ICollection<Order_Detail> Order_Details { get; set; }
    }
}