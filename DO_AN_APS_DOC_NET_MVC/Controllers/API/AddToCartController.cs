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
            var userId = User.Identity.GetUserId();
            var cart = new Cart
            {
                Id_Customer = userId,
                Id_Product = productDTO.Id_Product,
                Num = productDTO.Num
            };

            db.Carts.Add(cart);
            db.SaveChanges();

            return Ok();
        }


        //public IHttpActionResult Attend(AttendanceDto attendanceDto)
        //{
        //    var userId = User.Identity.GetUserId();
        //    if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
        //    {
        //        return BadRequest("The Attendance already exists!");
        //    }

        //    var attendance = new Attendance
        //    {
        //        CourseId = attendanceDto.CourseId,
        //        AttendeeId = userId
        //    };
        //    _dbContext.Attendances.Add(attendance);
        //    _dbContext.SaveChanges();

        //    return Ok();
        //}
    }
}
