using DO_AN_APS_DOC_NET_MVC.Models;
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
            var products = db.Products.Take(8).ToList();

            //var tees = db.Products.Where(i => i.Category.Id_Category == 1).Take(4).ToList();
            //var denims = db.Products.Where(i => i.Category.Id_Category == 2).Take(4).ToList();
            //var pants = db.Products.Where(i => i.Category.Id_Category == 3).Take(4).ToList();
            //var bags = db.Products.Where(i => i.Category.Id_Category == 4).Take(4).ToList();

            // load category
            var categories = db.Categories.ToList();

            var viewModel = new ProductsViewModel
            {
                Categories = categories,
                Products = products
                //Tees = tees,
                //Pants = pants,
                //Denims = denims,
                //Bags = bags
            };

            return View(viewModel);
        }

    }
}