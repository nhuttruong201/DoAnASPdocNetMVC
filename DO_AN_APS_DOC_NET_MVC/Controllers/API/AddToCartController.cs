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
using System.Web.Routing;

namespace DO_AN_APS_DOC_NET_MVC.Controllers.API
{
    public class AddToCartController : ApiController
    {
        private ApplicationDbContext db;
        public AddToCartController()
        {
            db = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult AddToCart(ProductDTO productDTO)
        {
            // Lấy id của khách hàng
            var userId = User.Identity.GetUserId();
            // Tìm sản phẩm cần thêm vào giỏ hàng
            Product product = db.Products.FirstOrDefault(p =>
                p.Id_Model == productDTO.Id_Model &&
                p.Color.Equals(productDTO.Color_Product) &&
                p.Size.Equals(productDTO.Size_Product)
                );
            // Kiểm tra sản phẩm tìm kiếm có tồn tại hay không
            if(product == null)
            {
                // Báo lỗi nếu sản phẩm không tồn tại
                return NotFound();
            }

            // Kiểm tra sản phẩm đã tồn tại trong giỏ hàng
            Cart cartCheck = db.Carts.FirstOrDefault(p => p.Id_Product == product.Id_Product && p.Id_Customer == userId);
            if (cartCheck != null)
            {
                return Ok("Sản phẩm đã có trong giỏ hàng!");
            }

            // Nếu chưa tồn tại thì tạo mới
            Cart cart = new Cart
            {
                Id_Customer = userId,
                Id_Product = product.Id_Product,
                Num = productDTO.Num
            };

            db.Carts.Add(cart);
            db.SaveChanges();

            return Ok("Thêm vào giỏ hàng thành công!");
        }
    }
}
