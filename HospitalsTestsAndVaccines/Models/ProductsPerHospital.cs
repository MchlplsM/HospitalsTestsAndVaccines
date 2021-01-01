using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
    public class ProductsPerHospital
    {
        public int ProductId { get; set; }
        public int HospitalId { get; set; }
        [Display(Name = "Διαθέσιμη Ποσότητα")]
        public int Quantity { get; set; }

        
    }
}
