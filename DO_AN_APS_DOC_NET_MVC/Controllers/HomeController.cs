using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using DO_AN_APS_DOC_NET_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_APS_DOC_NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var products = db.Products.OrderByDescending(p => p.Id_Model).Take(8).ToList();

            // Loại bỏ các sản phẩm cùng loại cùng màu (chỉ khác size)
            var productDistinct = products;
            for(int i=0; i<products.Count-1; i++)
            {
                for(int j=i+1; j<products.Count; j++)
                {
                    // cùng mẫu && cùng màu
                    if(products[i].Id_Model == products[j].Id_Model && products[i].Color.Equals(products[j].Color))
                    {
                        productDistinct.Remove(products[j]);
                    }
                }
            }

            // load category
            var categories = db.Categories.ToList();

            var viewModel = new ProductsViewModel
            {
                Categories = categories,
                Products = productDistinct
            };

            return View(viewModel);
        }
    }
}