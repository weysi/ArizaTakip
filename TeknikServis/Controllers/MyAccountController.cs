using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.Models;

namespace TeknikServis.Controllers
{

    public class MyAccountController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: MyAccount
        public ActionResult Index()
        {


            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            ApplicationSignInManager asn = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            var input = asn.PasswordSignIn(vm.Username, vm.Password, true, false);
            switch (input)
            {
                case SignInStatus.Success:

                    return RedirectToAction("InitPage", "Home");

                case SignInStatus.Failure:
                    return RedirectToAction("Login", "MyAccount");
                default:
                    break;
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(ApplicationUser user, string pass)
        {
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);

            var result = manager.Create(user, pass);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            else
                ViewBag.Errors = result.Errors;

            return RedirectToAction("Login");



        }
        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Login", "MyAccount");
        }
    }
}