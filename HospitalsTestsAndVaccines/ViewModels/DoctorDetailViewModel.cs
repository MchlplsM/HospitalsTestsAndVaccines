using HospitalsTestsAndVaccines.Core.Models;
using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.ViewModels
{
    public class DoctorDetailViewModel
    {
        public Doctor Doctor { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUser { get; set; }

        public IEnumerable<Appointment> UpcomingAppointments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}