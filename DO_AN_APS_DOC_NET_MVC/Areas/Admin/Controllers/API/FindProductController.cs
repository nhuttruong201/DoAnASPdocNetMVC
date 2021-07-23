using DO_AN_APS_DOC_NET_MVC.DTO;
using DO_AN_APS_DOC_NET_MVC.Models;
using DO_AN_APS_DOC_NET_MVC.Models.KingClothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using DO_AN_APS_DOC_NET_MVC.ViewModels;

namespace DO_AN_APS_DOC_NET_MVC.Areas.Admin.Controllers.API
{
    public class FindProductController : ApiController
    {
        private ApplicationDbContext db;
        public FindProductController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult FindProduct(ProductDTO productDTO)
        {
            Product product = db.Products.Find(productDTO.Id_Product);
            if(product == null)
            {
                return NotFound();
            }

            db.Entry(product).Reference(p => p.Product_Model).Load();
            
            ProductDTO pDTO = new ProductDTO
            {
                Id_Product = product.Id_Product,
                Id_Model = product.Id_Model,
                Name_Product = product.Product_Model.Name,
                Color_Product = product.Color,
                Price_Product = product.Product_Model.Price,
                Size_Product = product.Size,
                Image_Front = product.Image_Front
            };

            return Ok(pDTO);
        }
    }
}
