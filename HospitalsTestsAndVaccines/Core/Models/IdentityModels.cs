using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HospitalsTestsAndVaccines.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    
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

        //public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Customer> Customers { get; set; }

        //public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Hospital> Hospitals { get; set; }

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Product> Products { get; set; }
        
        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Appointment> Appointments { get; set; }

        //public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.ApplicationUser> IdentityUsers { get; set; } //NOT NEEDED

        //public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.> ApplicationUsers { get; set; }//NOT NEEDED
    }
}