using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DO_AN_APS_DOC_NET_MVC.Models;

namespace DO_AN_APS_DOC_NET_MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CategoryManager
        public ActionResult Index()
        {
            return View(db.Categories.OrderByDescending(p => p.Id_Category).ToList());
        }

        // GET: Admin/CategoryManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/CategoryManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Category,Name")] Category category, HttpPostedFileBase Image_Cover)
        {
            if(Image_Cover != null && Image_Cover.ContentLength > 0)
            {
                byte[] byteImage = new byte[Image_Cover.ContentLength];
                Image_Cover.InputStream.Read(byteImage, 0, Image_Cover.ContentLength);
                string fileName = System.IO.Path.GetFileName(DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + Image_Cover.FileName);
                string urlImage = Server.MapPath("~/Images/Categories/" + fileName);
                Image_Cover.SaveAs(urlImage);
                category.Image_Cover = "/Images/Categories/" + fileName;
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }

            return View(category);
        }

        // GET: Admin/CategoryManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/CategoryManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Category,Name")] Category category, HttpPostedFileBase EditImage)
        {
            if (ModelState.IsValid)
            {
                Category modifyCategory = db.Categories.Find(category.Id_Category);
                if (modifyCategory != null)
                {
                    if (EditImage != null && EditImage.ContentLength > 0)
                    {
                        byte[] byteImage = new byte[EditImage.ContentLength];
                        EditImage.InputStream.Read(byteImage, 0, EditImage.ContentLength);
                        string fileName = System.IO.Path.GetFileName(DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + EditImage.FileName);
                        string urlImage = Server.MapPath("~/Images/Categories/" + fileName);
                        EditImage.SaveAs(urlImage);
                        // cập nhật ảnh minh họa danh mục
                        modifyCategory.Image_Cover = "/Images/Categories/" + fileName;
                    }
                }
                // Cập nhật thông tin danh mục còn lại
                modifyCategory.Name = category.Name;
                db.Entry(modifyCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/CategoryManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/CategoryManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
