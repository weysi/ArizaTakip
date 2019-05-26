using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.Models;

namespace TeknikServis.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Initpage()
        {
            string uid = User.Identity.GetUserId();
            ApplicationUser app = db.Users.Find(uid);
            BrokenDevice bd = new BrokenDevice();
            bd.ApplicationUser = app;

           

            return View(bd);

        }
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            string enumValue = "";
           string userId= User.Identity.GetUserId();
          ApplicationUser user=db.Users.Find(userId);
            if (User.Identity.IsAuthenticated)
            {
                if (user.BrokenDevice == null)
                {
                    user.BrokenDevice = new BrokenDevice();
                    user.BrokenDevice.BrokenDeviceDetail = new BrokenDeviceDetail();
                    user.BrokenDevice.BrokenDeviceDetail.WhichStep =WhichStep.Alındı;
                }

           
                switch (user.BrokenDevice.BrokenDeviceDetail.WhichStep)
                {
                    case WhichStep.Alındı:
                        enumValue += "Alındı";
                        break;
                    case WhichStep.Teşhis:
                        enumValue += "Teshis";
                        break;

                    case WhichStep.Tedarik:
                        enumValue += "Tedarik";
                        break;
                    case WhichStep.Onarım:
                        enumValue += "Onarım";
                        break;
                    case WhichStep.Kargolama:
                        enumValue += "Kargolama";
                        break;
                    default:
                        enumValue += "";
                        break;

                }

                    ViewBag.Process = enumValue.ToString();
                
                       
                

               
                return View(user.BrokenDevice);
            }          
               
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}