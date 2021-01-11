using HospitalsTestsAndVaccines.Core.Models;
using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.ViewModels
{
    public class DoctorFormViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public bool IsAvailable { get; set; }


        [Required]

        public IEnumerable<Doctor> Doctors { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }
    }
}