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
using Microsoft.Ajax.Utilities;
using PagedList;

namespace DO_AN_APS_DOC_NET_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index(int view, int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            int pageNumber = (page ?? 1); // If(page == null) pageNumber = 1;
            var products = db.Products.Where(i => i.Id_Category == view).OrderByDescending(p => p.Id_Model).ToList();
            // Loại bỏ các sản phẩm cùng loại cùng màu (chỉ khác size)
            var productDistinct = products;
            for (int i = 0; i < products.Count - 1; i++)
            {
                for (int j = i + 1; j < products.Count; j++)
                {
                    // cùng mẫu && cùng màu
                    if (products[i].Id_Model == products[j].Id_Model && products[i].Color.Equals(products[j].Color))
                    {
                        productDistinct.Remove(products[j]);
                    }
                }
            }

            ViewBag.Title = db.Categories.Find(view).Name;
            ViewBag.UrlPageSelect = "/products?view=" + view + "&?page=";
            ViewBag.UrlPagePrevious = "/products?view=" + view + "&?page=" + (page - 1);
            ViewBag.UrlPageNext = "/products?view=" + view + "&?page=" + (page + 1);

            return View(productDistinct.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult All(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            //var products = db.Products.Select(p => new { p.Id_Model, p.Color }).Distinct().ToList();
            var products = db.Products.OrderByDescending(p => p.Id_Model).ToList();
            // Loại bỏ các sản phẩm cùng loại cùng màu (chỉ khác size)
            var productDistinct = products;
            for (int i = 0; i < products.Count - 1; i++)
            {
                for (int j = i + 1; j < products.Count; j++)
                {
                    // cùng mẫu && cùng màu
                    if (products[i].Id_Model == products[j].Id_Model && products[i].Color.Equals(products[j].Color))
                    {
                        productDistinct.Remove(products[j]);
                    }
                }
            }

            ViewBag.Title = "Tất Cả Sản Phẩm";
            ViewBag.UrlPageSelect = "/products/all?page=";
            ViewBag.UrlPagePrevious = "/products/all?page=" + (page - 1);
            ViewBag.UrlPageNext = "/products/all?page=" + (page + 1);

            return View(productDistinct.ToPagedList(pageNumber, pageSize));
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
