namespace TeknikServis.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeknikServis.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeknikServis.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TeknikServis.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var managerStore = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };

                managerStore.Create(role);
            }





            if (!context.Users.Any(u => u.UserName == "Veysi"))
            {
                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Veysi", Email = "uve.eng@outlook.com", Address = "aaaa", NameSurname = "Veysi Ocak", PhoneNumber = "555 444 333 222 " };

                manager.Create(user, "123456Aa!");
                manager.AddToRole(user.Id, "Admin");
            }


        }
    }
}
