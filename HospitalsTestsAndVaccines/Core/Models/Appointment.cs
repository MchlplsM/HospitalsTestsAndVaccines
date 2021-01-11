using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}