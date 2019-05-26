using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.Models;

namespace TeknikServis.Areas.Panel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BrokenDeviceController : Controller
    {
        // GET: Panel/BrokenDevice

        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult Create(string id)
        {
            
            ViewBag.Idsi = id;

            return View();
        }
        [HttpPost]
        public ActionResult Create(BrokenDevice dv)
        {
            ApplicationUser app = db.Users.Find(dv.UserId);
            BrokenDevice device = new BrokenDevice();
            if (ModelState.IsValid)
            {
                device.ApplicationUser = app;
                device.isGaranti = dv.isGaranti;
                device.ProductName = dv.ProductName;
                device.SerialNo = dv.SerialNo;
                device.UserId = dv.UserId;
                db.BrokenDevices.Add(device);
                db.SaveChanges();
                return RedirectToAction("Create", "BrokenDeviceDetail", new { id=dv.UserId });
       
             
            }
       
          



            return View();
        }
    }
}