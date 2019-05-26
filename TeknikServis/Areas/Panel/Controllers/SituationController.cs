using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.Models;

namespace TeknikServis.Areas.Panel.Controllers
{
    public class SituationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Panel/Situation
        [HttpGet]
        public ActionResult Index(string id)
        {
            ApplicationUser app = db.Users.Find(id);

            //var broke = db.BrokenDevices.Where(x => x.UserId == id).FirstOrDefault();
            if (app.BrokenDevice == null)
            {
                app.BrokenDevice = new BrokenDevice();
            }
            if (app.BrokenDevice.BrokenDeviceDetail == null)
            {
                app.BrokenDevice.BrokenDeviceDetail = new BrokenDeviceDetail();
            }
            return View(app);
        }
       [HttpPost]
        public ActionResult Index(WhichStep WhichStep,string AppId)
        {
          

            ApplicationUser app = db.Users.Find(AppId);
            app.BrokenDevice.BrokenDeviceDetail.WhichStep = WhichStep;
            db.Entry(app).State=EntityState.Modified;
            db.SaveChanges();



            return RedirectToAction("Index","Admin");
        }

        [HttpGet]
        public ActionResult Shipment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Shipment(Shipment sp,string appId)
        {
            return View();
        }

    }
}



