using DO_AN_APS_DOC_NET_MVC.DTO;
using DO_AN_APS_DOC_NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DO_AN_APS_DOC_NET_MVC.Areas.Admin.Controllers.API
{
    [Authorize]
    public class CheckCustomerController : ApiController
    {
        private ApplicationDbContext db;
        public CheckCustomerController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CheckCustomer(CustomerDTO customerDTO)
        {
            ApplicationUser user = db.Users.FirstOrDefault(p => p.PhoneNumber.Equals(customerDTO.PhoneNumber));
            if(user == null)
            {
                return NotFound();
            }    
            
            return Ok(user);
        }
    }
}
