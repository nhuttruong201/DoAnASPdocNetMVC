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

namespace DO_AN_APS_DOC_NET_MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductModelManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductModelManager
        public ActionResult Index()
        {
            return View(db.Product_Models.ToList());
        }

        // GET: Admin/ProductModelManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Model product_Model = db.Product_Models.Find(id);
            if (product_Model == null)
            {
                return HttpNotFound();
            }
            return View(product_Model);
        }

        // GET: Admin/ProductModelManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductModelManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Model,Name,Describe,Price")] Product_Model product_Model)
        {
            if (ModelState.IsValid)
            {
                db.Product_Models.Add(product_Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Model);
        }

        // GET: Admin/ProductModelManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Model product_Model = db.Product_Models.Find(id);
            if (product_Model == null)
            {
                return HttpNotFound();
            }
            return View(product_Model);
        }

        // POST: Admin/ProductModelManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Model,Name,Describe,Price")] Product_Model product_Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_Model);
        }

        // GET: Admin/ProductModelManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Model product_Model = db.Product_Models.Find(id);
            if (product_Model == null)
            {
                return HttpNotFound();
            }
            return View(product_Model);
        }

        // POST: Admin/ProductModelManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Model product_Model = db.Product_Models.Find(id);
            db.Product_Models.Remove(product_Model);
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
