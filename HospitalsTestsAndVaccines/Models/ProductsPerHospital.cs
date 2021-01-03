using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
    public class ProductsPerHospital
    {
        
        public int ProductId { get; set; }
        //------------------------------
        public int HospitalId { get; set; }
        //-----------------------------
        [Display(Name = "Διαθέσιμη Ποσότητα")]
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Hospital Hospital { get; set; }


    }
}
