using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Display(Name = "Ημερομηνία Παραγγελίας")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [Required]
        public Product Product { get; set; }

        [Display(Name = "Συνολικό Ποσό")]
        public double TotalAmount { get; set; }

        public bool OrderStatus { get; set; }
        //PaidWithCard OR PayWhenAtHospital
        //public int PaymentId { get; set; } Should we use it here?
    }
}
//OrderID  ProductID
//  1       1/2
//  2       2/1
//  3       4