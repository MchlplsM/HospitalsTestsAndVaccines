using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        public string HospitalName { get; set; }
    }
}