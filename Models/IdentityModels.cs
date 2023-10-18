using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NextGenLife.Models
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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PolicyPlan> PolicyPlans { get; set; }

        public DbSet<PolicyAppliction> PolicyApplictions { get; set; }
        public DbSet<ApprovedPolicy> approvedPolicies { get; set; }
        public DbSet<PayFastSettings> payFastSettings { get; set; }
        public DbSet<PolicyClaim> PolicyClaims { get; set; }

        public DbSet<UsersView> usersViews { get; set; }





        //public DbSet<FoodDeliveryChoice> FoodDeliveryChoice { get; set; }

        public DbSet<RolesView> RolesViews { get; set; }

        public DbSet<IdentityUserRole> UserInRole { get; set; }
        // public DbSet<ApplicationUser> appUsers { get; set; }
        public DbSet<ApplicationRole> appRoles { get; set; }
        public DbSet<ApprovedPolicyClaim> approvedPolicyClaims { get; set; }





    }
}