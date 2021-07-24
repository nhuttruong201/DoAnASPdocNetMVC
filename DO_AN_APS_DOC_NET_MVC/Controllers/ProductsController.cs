using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using DO_AN_APS_DOC_NET_MVC.ViewModels;

namespace DO_AN_APS_DOC_NET_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index(int view)
        {
            var products = db.Products.Where(i => i.Id_Category == view).ToList();
            // load category
            var categories = db.Categories.ToList();
            var viewModel = new ProductsViewModel
            {
                Categories =categories,
                Products = products,
                Heading = db.Categories.Find(view).Name
            };

            return View(viewModel);
        }

        public ActionResult All()
        {
            var products = db.Products.ToList();
            var categories = db.Categories.ToList();
            var viewModel = new ProductsViewModel
            {
                Categories = categories,
                Products = products,
                Heading = "Tất cả sản phẩm"
            };
            return View(viewModel);
        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product productDetail = db.Products.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            db.Entry(productDetail).Reference(i => i.Category).Load();

            // Sản phẩm liên quan
            var relatedProducts = db.Products.Where(i => i.Id_Category == productDetail.Id_Category && i.Id_Product != id).Take(8).ToList();

            var viewModel = new ProductsViewModel
            {
                ProductDetail = productDetail,
                Products = relatedProducts
            };

            return View(viewModel);
        }
    }
}
