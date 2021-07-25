using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DO_AN_APS_DOC_NET_MVC.Models
{
    public class Category
    {
        [Key]
        public int Id_Category { get; set; }
        [Display(Name = "Danh Mục")]
        [Required(ErrorMessage = "Không được bỏ trống!")]
        public string Name { get; set; }

        [Display(Name = "Ảnh Danh Mục")]
        public string Image_Cover { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}