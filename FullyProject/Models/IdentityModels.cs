using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FullyProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string JobName { get; set; }
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
        //, throwIfV1Schema: false
        public ApplicationDbContext(): base("DefaultConnection")
        { 
            //Database.SetInitializer(new PropertyDBInitializer());
        }
        
            //base("DefaultConnection", throwIfV1Schema: false)
        
        public DbSet<CarOffer> CarOffer { get; set; }
        public DbSet<ContactInfoMessage> ContactInfoMessage { get; set; }
        public DbSet<CurrencyType> CurrencyType { get; set; }
        public DbSet<DistanceUnit> DistanceUnit { get; set; }
        //public DbSet<Manager> Manager { get; set; }
       // public DbSet<OfferType> OfferType { get; set; }
        public DbSet<OnlineProject> OnlineProject { get; set; }
        public DbSet<Photo> Photo { get; set; }
        //public DbSet<PhotoOwner> PhotoOwner { get; set; }
       


        public DbSet<PropertyOffer> PropertyOffer { get; set; }

       // public DbSet<PropertyDetial> PropertyDetial { get; set; }
        // public DbSet<PropertyImage> PropertyImage { get; set; }
        public DbSet<PropertyState> PropertyState { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<Service> Service { get; set; }

        public DbSet<SubscriptionEmail> SubscriptionEmail { get; set; }
        
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Claim");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");

        }
    }
}