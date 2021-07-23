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
            var orders = db.Orders.Include(o => o.Product);
            return View(orders.ToList());
        }


        public ActionResult NewOrder()
        {
            var orders = db.Orders.Where(i => i.IsCheck == false).Include(i => i.Product).Include(i => i.Customer).ToList();

            var viewModel = new OrderViewModel
            {
                Orders = orders
            };
            return View(viewModel);
        }

        public ActionResult ConfirmOrder(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if(order == null)
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
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            ViewBag.Id_Product = new SelectList(db.Products, "Id_Product", "Image_Front");
            return View();
        }

        // POST: Admin/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Order,Num,PhoneNumber,Date,Message,Address,Id_Customer,IsCheck,Id_Product")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Product = new SelectList(db.Products, "Id_Product", "Image_Front", order.Id_Product);
            return View(order);
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Id_Product = new SelectList(db.Products, "Id_Product", "Image_Front", order.Id_Product);
            return View(order);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Order,Num,PhoneNumber,Date,Message,Address,Id_Customer,IsCheck,Id_Product")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Product = new SelectList(db.Products, "Id_Product", "Image_Front", order.Id_Product);
            return View(order);
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
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
            return View(order);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
