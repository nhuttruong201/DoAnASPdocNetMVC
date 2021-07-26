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

namespace DO_AN_APS_DOC_NET_MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class OrderManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Order
        public ActionResult Index()
        {
            var orders = db.Orders;
            return View(orders.ToList());
        }


        public ActionResult NewOrder()
        {
            var orders = db.Orders.Where(i => i.IsCheck == false).Include(i => i.Customer).OrderByDescending(p => p.Id_Order).ToList();

            var viewModel = new OrderViewModel
            {
                Orders = orders
            };
            return View(viewModel);
        }

        public ActionResult ConfirmOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            order.IsCheck = true;
            db.SaveChanges();

            // Chuyển đơn hàng qua tab chờ thanh toán
            // Lập bill mới
            Bill bill = new Bill
            {
                Date = DateTime.Now.ToString("dd/MM/yyyy"),
                Id_Customer = order.Id_Customer,
                // chờ thanh toán
                IsPayed = false
            };
            db.Bills.Add(bill);
            db.SaveChanges();
            // Lấy Id bill vừa tạo
            int id_bill_current = db.Bills.Max(m => m.Id_Bill);
            // Xử lý thêm bào bill detail từ order detail
            var orderDetails = db.Order_Details.Where(p => p.Id_Order == order.Id_Order).ToList();
            foreach(Order_Detail item in orderDetails)
            {
                Bill_Detail bill_Detail = new Bill_Detail
                {
                    Id_Bill = id_bill_current,
                    Id_Product = item.Id_Product,
                    Num = item.Num
                };
                db.Bill_Details.Add(bill_Detail);
                db.SaveChanges();
                // Cập nhật số lượng sản phẩm trong kho
                Product product = db.Products.Find(item.Id_Product);
                product.Num -= item.Num;
                db.SaveChanges();
            }

            //return RedirectToAction("NewOrder", "OrderManager");
            return RedirectToAction("Waiting", "Payment");
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            var orderDetail = db.Order_Details.Where(p => p.Id_Order == id).Include(i => i.Product).Include(i => i.Order).ToList();

            var viewModel = new OrderViewModel
            {
                Order_Details = orderDetail,
                Order = order
            };
            return View(viewModel);
        }

    }
}
