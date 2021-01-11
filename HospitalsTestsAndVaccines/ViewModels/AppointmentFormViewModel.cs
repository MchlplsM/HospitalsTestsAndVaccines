﻿using HospitalsTestsAndVaccines.Core.Models;
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
        public string Id { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }


        [Required]
        public string Detail { get; set; }

        [Required]
        public bool Status { get; set; }
        [Required]
        public string Doctor { get; set; }

        public IEnumerable<Doctor> Doctors { get; set; }


        [Required]
        public string ApplicationUser { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        
        public string Heading { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
        public string Product { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public DateTime GetStartDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

    }
}