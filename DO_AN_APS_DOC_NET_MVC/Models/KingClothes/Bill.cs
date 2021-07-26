using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.Models.KingClothes
{
    public class Bill
    {
        [Key]
        public int Id_Bill { get; set; }
        [Display(Name = "Ngày Lập")]
        [Required]
        public string Date { get; set; }
        public string Id_Customer { get; set; }
        public bool IsPayed { get; set; }
        public ApplicationUser Customer { get; set; }
        public ICollection<Bill_Detail> Bill_Details { get; set; }
    }
}