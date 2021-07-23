using DO_AN_APS_DOC_NET_MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DO_AN_APS_DOC_NET_MVC.ViewModels;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;

namespace DO_AN_APS_DOC_NET_MVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private ApplicationDbContext db;
        public OrderController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Order
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var carts = db.Carts.Where(i => i.Id_Customer == userId).Include(i => i.Product).ToList();
            var viewModel = new CartsViewModel
            {
                Carts = carts
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(
            string phoneNumber, 
            string addressDetail, 
            string district, 
            string ward, 
            string message)
        {
            var userId = User.Identity.GetUserId();

            var carts = db.Carts.Where(i => i.Id_Customer == userId).ToList();

            foreach(Cart i in carts)
            {
                Order order = new Order
                {
                    Id_Customer = userId,
                    Id_Product = i.Id_Product,
                    Num = i.Num,
                    PhoneNumber = phoneNumber,
                    Address = addressDetail + ", " + ward + ", " + district + ", Tp.HCM",
                    Message = message,
                    Date = DateTime.Now.ToString("dd/MM/yyyy"),
                    IsCheck = false
                };

                db.Orders.Add(order);
                db.SaveChanges();
            }

            // Xóa sản phẩm trong giỏ hàng (Đã mua)
            foreach(Cart i in carts)
            {
                db.Carts.Remove(i);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Cart");
        }
    }
}