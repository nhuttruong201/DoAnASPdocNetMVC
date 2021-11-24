using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using DO_AN_APS_DOC_NET_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            var categories = db.Categories.ToList();
            List<Product> products = new List<Product>();
            foreach(var item in categories)
            {
                var productTemp = db.Products.Include(i => i.Product_Model).Where(i => i.Id_Category == item.Id_Category).OrderByDescending(p => p.Id_Model).Take(4).ToList();
                foreach(var pTemp in productTemp)
                {
                    products.Add(pTemp);
                }
            }

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


            var viewModel = new ProductsViewModel
            {
                // load category carousel
                Categories = categories,
                Products = productDistinct
            };

            return View(viewModel);
        }
    }
}