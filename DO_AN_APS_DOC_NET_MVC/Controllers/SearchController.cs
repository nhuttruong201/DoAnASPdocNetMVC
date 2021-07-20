using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_APS_DOC_NET_MVC.Controllers
{
    public class SearchController : Controller
    {

        private ApplicationDbContext db;
        public SearchController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Search
        public ActionResult Index(string search)
        {
            // Kiểm tra input rỗng
            if (String.IsNullOrEmpty(search))
            {
                return RedirectToAction("Index", "Home");
            }

            var results = db.Products.Where(i => i.Name.Contains(search)).ToList();
            var viewModel = new ProductsViewModel
            { 
                Products = results,
                strSearch = search
            };
         
            return View(viewModel);
        }
    }
}