using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Core.Models
{
    public class Doctor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public string Address { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public Doctor()
        {
            Appointments = new Collection<Appointment>();
        }

    }
}