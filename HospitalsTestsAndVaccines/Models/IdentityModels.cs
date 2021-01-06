using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HospitalsTestsAndVaccines.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Όνομα")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Επίθετο")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Τηλέφωνο")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Α.Μ.Κ.Α.")]
        public string Amka { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ημερομηνία Γέννησης")]
        public string DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Πρ.Υγείας")]
        public string HealthIssues { get; set; }
        [Required]
        [Display(Name = "Διεύθυνση Κατοικίας")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Πόλη")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Ταχ. Κώδικας")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Νομός")]
        public string State { get; set; }
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

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Customer> Customers { get; set; }

        //public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Hospital> Hospitals { get; set; }

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Order> Orders { get; set; }

        //public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.ApplicationUser> IdentityUsers { get; set; } //NOT NEEDED

        //public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.> ApplicationUsers { get; set; }//NOT NEEDED
    }
}