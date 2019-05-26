using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.Models;

namespace TeknikServis.Areas.Panel.Controllers
{
    public class BrokenDeviceDetailController : Controller
    {
        ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: Panel/BrokenDeviceDetail
        public ActionResult Create(string id)
        {


            BrokenDevice bd = ctx.BrokenDevices.Where(x => x.UserId == id).FirstOrDefault();
           
         
            return View(bd);
        }
        [HttpPost]
       
        public ActionResult Create(BrokenDeviceDetail bd)
        {
           
            if (ModelState.IsValid)
            {
               
                ctx.BrokenDeviceDetails.Add(bd);
                ctx.SaveChanges();
                return RedirectToAction("Index", "Admin");


            }
            return View();


        }
    }
}