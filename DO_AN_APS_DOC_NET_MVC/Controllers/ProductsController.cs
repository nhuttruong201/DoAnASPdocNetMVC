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
            var products = db.Products.Where(i => i.Id_Category == view).Include(i => i.Product_Model).OrderByDescending(p => p.Id_Model).ToList();
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
            ViewBag.Page = page;

            ViewBag.Title = db.Categories.Find(view).Name;
            ViewBag.UrlPageSelect = "/products?view=" + view + "&page=";
            ViewBag.UrlPagePrevious = "/products?view=" + view + "&page=" + (page - 1);
            ViewBag.UrlPageNext = "/products?view=" + view + "&page=" + (page + 1);

            return View(productDistinct.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Sale(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 8;
            int pageNumber = (page ?? 1);


            var productModelS = db.Product_Models.Where(p => p.Sale > 0).ToList();

            List<Product> listProductSale = new List<Product>();
            foreach (var item in productModelS)
            {
                Product productTemp = db.Products.Include(i => i.Category).FirstOrDefault(p => p.Id_Model == item.Id_Model);
                listProductSale.Add(productTemp);
            }

            ViewBag.Page = page;
            ViewBag.Title = "Sale";
            ViewBag.UrlPageSelect = "/products/sale?page=";
            ViewBag.UrlPagePrevious = "/products/sale?page=" + (page - 1);
            ViewBag.UrlPageNext = "/products/sale?page=" + (page + 1);

            return View(listProductSale.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult All(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var products = db.Products.Include(i => i.Product_Model).Include(i => i.Category).OrderByDescending(p => p.Id_Model).ToList();
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
            ViewBag.Page = page;
            ViewBag.Title = "All";
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
            db.Entry(productDetail).Reference(i => i.Product_Model).Load();

            // Sản phẩm liên quan
            var relatedProducts = db.Products.Include(i => i.Product_Model).Where(i => i.Id_Category == productDetail.Id_Category && i.Id_Product != id).Take(8).ToList();
            // Loại bỏ các sản phẩm cùng loại cùng màu (chỉ khác size)
            var relatedProductsDistinct = relatedProducts;
            for (int i = 0; i < relatedProducts.Count - 1; i++)
            {
                for (int j = i + 1; j < relatedProducts.Count; j++)
                {
                    // cùng mẫu && cùng màu
                    if (relatedProducts[i].Id_Model == relatedProducts[j].Id_Model && relatedProducts[i].Color.Equals(relatedProducts[j].Color))
                    {
                        relatedProductsDistinct.Remove(relatedProducts[j]);
                    }
                }
            }

            var viewModel = new ProductsViewModel
            {
                ProductDetail = productDetail,
                Products = relatedProductsDistinct
            };

            return View(viewModel);
        }
    }
}
