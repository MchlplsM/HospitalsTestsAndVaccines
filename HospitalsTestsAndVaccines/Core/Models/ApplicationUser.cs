using HospitalsTestsAndVaccines.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
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
        public ICollection<Appointment> Appointments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public ApplicationUser()
        {
            Appointments = new Collection<Appointment>();
        }
    }
}