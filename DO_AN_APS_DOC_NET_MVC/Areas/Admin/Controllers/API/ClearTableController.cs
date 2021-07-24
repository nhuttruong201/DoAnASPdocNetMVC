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
    public class ClearTableController : ApiController
    {
        private ApplicationDbContext db;
        public ClearTableController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult ClearTable()
        {
            db.Bill_Temps.RemoveRange(db.Bill_Temps);
            db.SaveChanges();
            return Ok();
        }
    }
}
