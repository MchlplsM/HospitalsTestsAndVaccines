using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string CustomerName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MinLength(11)]
        public int AMKA { get; set; }
        public string HealthIssues { get; set; }
    }
}