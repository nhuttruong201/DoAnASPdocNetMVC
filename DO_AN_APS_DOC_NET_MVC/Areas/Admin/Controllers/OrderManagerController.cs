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
            return RedirectToAction("NewOrder", "OrderManager");
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
