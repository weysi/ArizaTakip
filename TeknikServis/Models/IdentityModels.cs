using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TeknikServis.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string NameSurname { get; set; }
        public string Address { get; set; }

        public virtual BrokenDevice BrokenDevice { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<BrokenDevice> BrokenDevices { get; set; }
        public virtual DbSet<BrokenDeviceDetail> BrokenDeviceDetails { get; set; }

        public ApplicationDbContext()
            : base("TeknikDbContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasKey(x => x.Id);
            modelBuilder.Entity<BrokenDevice>().HasKey(x => x.Id);
            modelBuilder.Entity<BrokenDeviceDetail>().HasKey(x => x.Id);

            #region Relation

            modelBuilder.Entity<BrokenDevice>().HasRequired(x => x.ApplicationUser).WithOptional(x => x.BrokenDevice);
            modelBuilder.Entity<BrokenDeviceDetail>().HasRequired(x => x.BrokenDevice).WithOptional(x => x.BrokenDeviceDetail);
            modelBuilder.Entity<Shipment>().HasRequired(x => x.BrokenDevice).WithOptional(x => x.Shipment);
            #endregion




            base.OnModelCreating(modelBuilder);
        }
    }
}