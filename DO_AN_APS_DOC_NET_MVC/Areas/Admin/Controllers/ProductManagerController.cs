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
            var products = db.Products.Include(p => p.Category).Include(p => p.Product_Model).OrderByDescending(p => p.Id_Product);
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
        public ActionResult Create([Bind(Include = "Id_Product,Color,Size,Num,Id_Category,Id_Model")] Product product, HttpPostedFileBase Image_Front, HttpPostedFileBase Image_Back)
        {
            if(Image_Front != null && Image_Front.ContentLength > 0)
            {
                byte[] byteImage = new byte[Image_Front.ContentLength];
                Image_Front.InputStream.Read(byteImage, 0, Image_Front.ContentLength);
                string fileName = System.IO.Path.GetFileName(DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + Image_Front.FileName);
                string urlImage = Server.MapPath("~/Images/Products/" + fileName);
                Image_Front.SaveAs(urlImage);
                product.Image_Front = "/Images/Products/" + fileName;
            }

            if (Image_Back != null && Image_Back.ContentLength > 0)
            {
                byte[] byteImage = new byte[Image_Back.ContentLength];
                Image_Back.InputStream.Read(byteImage, 0, Image_Back.ContentLength);
                string fileName = System.IO.Path.GetFileName(DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + Image_Back.FileName);
                string urlImage = Server.MapPath("~/Images/Products/" + fileName);
                Image_Back.SaveAs(urlImage);
                product.Image_Back = "/Images/Products/" + fileName;
            }

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
        public ActionResult Edit([Bind(Include = "Id_Product,Color,Size,Num,Id_Category,Id_Model")] 
            Product product, HttpPostedFileBase EditImageFront, HttpPostedFileBase EditImageBack)
        {
            if (ModelState.IsValid)
            {
                Product modifyProduct = db.Products.Find(product.Id_Product);
                if(modifyProduct != null)
                {
                    if (EditImageFront != null && EditImageFront.ContentLength > 0)
                    {
                        byte[] byteImage = new byte[EditImageFront.ContentLength];
                        EditImageFront.InputStream.Read(byteImage, 0, EditImageFront.ContentLength);
                        string fileName = System.IO.Path.GetFileName(DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + EditImageFront.FileName);
                        string urlImage = Server.MapPath("~/Images/Products/" + fileName);
                        EditImageFront.SaveAs(urlImage);
                        modifyProduct.Image_Front = "/Images/Products/" + fileName;
                    }

                    if (EditImageBack != null && EditImageBack.ContentLength > 0)
                    {
                        byte[] byteImage = new byte[EditImageBack.ContentLength];
                        EditImageBack.InputStream.Read(byteImage, 0, EditImageBack.ContentLength);
                        string fileName = System.IO.Path.GetFileName(DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + EditImageBack.FileName);
                        string urlImage = Server.MapPath("~/Images/Products/" + fileName);
                        EditImageBack.SaveAs(urlImage);
                        modifyProduct.Image_Back = "/Images/Products/" + fileName;
                    }
                }
                db.Entry(modifyProduct).State = EntityState.Modified;
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
