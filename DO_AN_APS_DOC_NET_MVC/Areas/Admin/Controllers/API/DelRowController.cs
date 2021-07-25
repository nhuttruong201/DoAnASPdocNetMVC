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
    public class DelRowController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IHttpActionResult DelRow(ProductDTO productDTO)
        {
            Bill_Temp bill_Temp = db.Bill_Temps.FirstOrDefault(p => p.Id_Product == productDTO.Id_Product);
            if(bill_Temp == null)
            {
                return NotFound();
            }
            db.Bill_Temps.Remove(bill_Temp);
            db.SaveChanges();

            var billTempCurrent = db.Bill_Temps.ToList();

            return Ok(billTempCurrent);
        }
    }
}
