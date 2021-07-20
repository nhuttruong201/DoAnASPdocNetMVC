using DO_AN_APS_DOC_NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using Microsoft.AspNet.Identity;

namespace DO_AN_APS_DOC_NET_MVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ApplicationDbContext db;
        public CartController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Cart
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var carts = db.Carts.Where(i => i.Id_Customer == userId).Include(i => i.Product).ToList();
                
            return View(carts);
        }

        public ActionResult Delete(int? id_product)
        {
            Cart item = db.Carts.FirstOrDefault(i => i.Id_Product == id_product);
            if (item == null)
            {
                return HttpNotFound();
            }
            db.Carts.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
    }
}