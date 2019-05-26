using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.Models;
using System.Data.Entity;
namespace TeknikServis.Areas.Panel.Controllers
{
    public class ShipmentController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Panel/Shipment 
        [HttpPost]
        public ActionResult Index(Shipment sp)
        {
            if (!db.Shipments.Any(x => x.Id == sp.Id))
            {
                db.Shipments.Add(sp);
                db.SaveChanges();
            }
            else
            {
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
            }
       
            return RedirectToAction("Index","Admin");




        }
    }
}