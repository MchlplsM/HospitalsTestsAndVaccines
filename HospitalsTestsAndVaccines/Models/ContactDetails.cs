using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
    public class ContactDetails
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int HospitalId { get; set; }
        [Required]
        [Phone]
        [MinLength(10)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; } 
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string State { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

    }
}