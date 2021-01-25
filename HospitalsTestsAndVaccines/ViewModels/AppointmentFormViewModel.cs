using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.ViewModels
{
    public class AppointmentFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public string ApplicationUser { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        
        public string Heading { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public int Product { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public DateTime GetStartDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

    }
}