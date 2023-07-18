using System.Data.Entity;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading.Tasks;
using FestivalMarket.Models.EF;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FestivalMarket.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<Category> Category { get; set; }
     
        public DbSet<News> News { get; set; }

        public DbSet<Events> Events { get; set; }

        public DbSet<EventsImage> EventsImage { get; set; }

        public DbSet<Introduction> Introduction { get; set; }

        public DbSet<Product> Product { get; set; }
      
        public DbSet<SystemSetting> SystemSetting { get; set; }
        public DbSet<Contact> Contact { get; set; }

        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Sales> Sales { get; set; }

     
        public DbSet<Slides> Slides { get; set; }
        public DbSet<FilmsView> FilmsView { get; set; }

        public DbSet<CategoryFilm> CategoryFilm { get; set; }

        public DbSet<EventsContactCustomer> EventsContactCustomer { get; set; }
        public static ApplicationDbContext Create()
        
        {
            return new ApplicationDbContext();
        }
    }
}