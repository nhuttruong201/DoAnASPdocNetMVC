using DO_AN_APS_DOC_NET_MVC.DTO;
using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DO_AN_APS_DOC_NET_MVC.Controllers.API
{
    public class UpdateNumController : ApiController
    {
        private ApplicationDbContext db;
        public UpdateNumController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult UpdateNum(ProductDTO productDTO)
        {
            var userId = User.Identity.GetUserId();
            Cart cart = db.Carts.FirstOrDefault(p => p.Id_Customer == userId && p.Id_Product == productDTO.Id_Product);
            if(cart == null)
            {
                return NotFound();
            }
            // Cập nhật số lượng sản phẩm trong giỏ hàng
            cart.Num = productDTO.Num;
            db.SaveChanges();
            return Ok();
        }
    }
}
