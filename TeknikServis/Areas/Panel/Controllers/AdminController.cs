using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.Models;

namespace TeknikServis.Areas.Panel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Panel/Admin
 
        public ActionResult Index()
        {
  
            return View(db.Users);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ApplicationUser app=db.Users.Find(id);
                ViewBag.Roles = db.Roles.ToList().Select(x => new  SelectListItem{Text=x.Name,Value=x.Id });
                return View(app);
            }
            
         
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUser app,string Password, string role)
        {
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);


    
            if (ModelState.IsValid)
            {
                ApplicationUser updateUser = db.Users.Find(app.Id);
     
                if (role == "1")
                {
                    manager.AddToRole(app.Id,"User");
            
                }
              
                db.Entry(updateUser).CurrentValues.SetValues(app);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Roles = db.Roles.ToList().Select(x =>new SelectListItem { Text = x.Name, Value = x.Id });
            return View();
           
        }
        [HttpGet]
      public ActionResult CreateNew()
        {
            ViewBag.Roles = db.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id });
            return View();
        }

        [HttpPost]
        public ActionResult CreateNew(ApplicationUser user,string role, string pass)
        {
            string rolea = "";
            ViewBag.Roles = db.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id });
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);

            if (role == "1")
            {
                rolea = "User";

            }
            var result = manager.Create(user, pass);
          
            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, rolea);
                return RedirectToAction("Index", "Admin");
            }       

            else
                ViewBag.Errors = result.Errors;

            return RedirectToAction("Login");
          
        }

       
    }

 
}