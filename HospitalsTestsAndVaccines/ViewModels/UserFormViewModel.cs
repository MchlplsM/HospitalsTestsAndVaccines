using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.ViewModels
{
    public class UserFormViewModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Display(Name = "Ημερομηνία Γέννησης")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }

        [Required]
        [MinLength(11)]
        public string Amka { get; set; }
        public string HealthIssues { get; set; }

        public UserFormViewModel(ApplicationUser applicationUser)
        {
            Id = applicationUser.Id;
            FirstName = applicationUser.FirstName;
            LastName = applicationUser.LastName;
            DateOfBirth = applicationUser.DateOfBirth;
            Amka = applicationUser.Amka;
            HealthIssues = applicationUser.HealthIssues;
        }
    }
}