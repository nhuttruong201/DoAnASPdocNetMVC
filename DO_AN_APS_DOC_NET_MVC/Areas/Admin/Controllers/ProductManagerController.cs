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
    public class ProductManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductManager
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Product_Model);
            return View(products.ToList());
        }

        // GET: Admin/ProductManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/ProductManager/Create
        public ActionResult Create()
        {
            ViewBag.Id_Category = new SelectList(db.Categories, "Id_Category", "Name");
            ViewBag.Id_Model = new SelectList(db.Product_Models, "Id_Model", "Name");
            return View();
        }

        // POST: Admin/ProductManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Product,Image_Front,Image_Back,Color,Size,Num,Id_Category,Id_Model")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Category = new SelectList(db.Categories, "Id_Category", "Name", product.Id_Category);
            ViewBag.Id_Model = new SelectList(db.Product_Models, "Id_Model", "Name", product.Id_Model);
            return View(product);
        }

        // GET: Admin/ProductManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Category = new SelectList(db.Categories, "Id_Category", "Name", product.Id_Category);
            ViewBag.Id_Model = new SelectList(db.Product_Models, "Id_Model", "Name", product.Id_Model);
            return View(product);
        }

        // POST: Admin/ProductManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Product,Image_Front,Image_Back,Color,Size,Num,Id_Category,Id_Model")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Category = new SelectList(db.Categories, "Id_Category", "Name", product.Id_Category);
            ViewBag.Id_Model = new SelectList(db.Product_Models, "Id_Model", "Name", product.Id_Model);
            return View(product);
        }

        // GET: Admin/ProductManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/ProductManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
