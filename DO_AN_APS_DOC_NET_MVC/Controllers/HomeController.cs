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
            var products = db.Products.OrderByDescending(p => p.Id_Product).Take(8).ToList();
            // load category
            var categories = db.Categories.ToList();

            var viewModel = new ProductsViewModel
            {
                Categories = categories,
                Products = products
            };

            return View(viewModel);
        }
    }
}