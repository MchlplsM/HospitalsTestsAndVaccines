using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
    public class ContactDetails
    {
        public int CustomerId { get; set; }
        public int HospitalId { get; set; }
        [Required]
        //attribute to make it phone
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
        [Required]
        //attribute to make it email
        public string Email { get; set; }

    }
}