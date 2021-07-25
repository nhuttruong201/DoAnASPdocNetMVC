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

            // lập phiếu order
            Order order = new Order
            {
                Id_Customer = userId,
                PhoneNumber = phoneNumber,
                Address = addressDetail + ", " + ward + ", " + district + ", Tp.HCM",
                Message = message,
                Date = DateTime.Now.ToString("dd/MM/yyyy"),
                IsCheck = false
            };
            db.Orders.Add(order);
            db.SaveChanges();

            // Xử lý chi tiết phiểu order
            // Lấy id phiếu order vừa tạo ở trên
            int id_order_current = db.Orders.Max(m => m.Id_Order);
            // Lấy thông tin sản phẩm cần order
            foreach (Cart item in carts)
            {
                Order_Detail order_Detail = new Order_Detail
                {
                    Id_Order = id_order_current,
                    Id_Product = item.Id_Product,
                    Num = item.Num
                };
                db.Order_Details.Add(order_Detail);
                db.SaveChanges();
            }

            // Xóa tất cả sản phẩm trong giỏ hàng (Đã mua)
            db.Carts.RemoveRange(db.Carts);
            db.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }
    }
}