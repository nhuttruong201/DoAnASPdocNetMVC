using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DO_AN_APS_DOC_NET_MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PaymentController : Controller
    {
        private ApplicationDbContext db;
        public PaymentController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Admin/Payment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Waiting()
        {
            var listBillWaiting = db.Bills.Include(i => i.Customer).OrderByDescending(p => p.Id_Bill).Where(p => p.IsPayed == false).ToList();
            return View(listBillWaiting);
        }
        [HttpPost]
        public ActionResult PayWait(int idBill)
        {
            Bill bill = db.Bills.Find(idBill);
            if(bill == null)
            {
                return HttpNotFound();
            }

            bill.IsPayed = true;
            db.SaveChanges();

            return RedirectToAction("Waiting", "Payment");
        }


        [HttpPost]
        public ActionResult Pay(string id_customer)
        {
            // Lập hóa đơn thanh toán
            Bill bill = new Bill
            {
                Date = DateTime.Now,
                Id_Customer = id_customer,
                IsPayed = true
            };
            db.Bills.Add(bill);
            db.SaveChanges();

            // Xử lý chi tiết hóa đơn (Bill_Detail)
            // Lấy ID bill vừa tạo (id lớn nhất)
            int id_bill_current = db.Bills.Max(m => m.Id_Bill);
            // Lấy thông tin sản phẩm cần thanh toán
            var billTemp = db.Bill_Temps.ToList();
            // Gán dữ liệu vào bill detail
            foreach(Bill_Temp item in billTemp)
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

            // Xóa dữ liệu bill temp
            db.Bill_Temps.RemoveRange(db.Bill_Temps);
            db.SaveChanges();


            return RedirectToAction("Index", "Admin");
        }

        public ActionResult History()
        {
            var Bills = db.Bills.Where(p => p.IsPayed == true).OrderByDescending(p => p.Id_Bill).ToList();
            return View(Bills);
        }
    }
}