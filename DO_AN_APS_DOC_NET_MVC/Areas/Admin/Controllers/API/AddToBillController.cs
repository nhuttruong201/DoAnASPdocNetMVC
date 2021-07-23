using DO_AN_APS_DOC_NET_MVC.DTO;
using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DO_AN_APS_DOC_NET_MVC.Areas.Admin.Controllers.API
{
    [Authorize]
    public class AddToBillController : ApiController
    {
        private ApplicationDbContext db;
        public AddToBillController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AddToBill(ProductDTO productDTO)
        {
            if(db.Bill_Temps.Any(p => p.Id_Product == productDTO.Id_Product))
            {
                return NotFound();
            }

            Product product = db.Products.Find(productDTO.Id_Product);
            db.Entry(product).Reference(p => p.Product_Model).Load();
            Bill_Temp bill_Temp = new Bill_Temp
            {
                Id_Product = product.Id_Product,
                Name = product.Product_Model.Name,
                Image_Front = product.Image_Front,
                Color = product.Color,
                Size = product.Size,
                Price = product.Product_Model.Price,
                Num = 1
            };
            db.Bill_Temps.Add(bill_Temp);
            db.SaveChanges();

            // Load Table Product
            var bill_temp_current = db.Bill_Temps.ToList();
          
            return Ok(bill_temp_current);
        }
    }
}
