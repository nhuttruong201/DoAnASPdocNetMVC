using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.Models.KingClothes
{
    public class Bill_Detail
    {
        [Key]
        [Column(Order = 1)]
        public int Id_Bill { get; set; }
        public Bill Bill { get; set; }
        [Key]
        [Column(Order = 2)]

        public int Id_Product { get; set; }
        public Product Product { get; set; }
        [Display(Name = "Số Lượng")]
        [Required]
        public int Num { get; set; }
    }
}