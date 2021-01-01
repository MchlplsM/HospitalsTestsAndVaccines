using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Data
{
    public class HospitalsTestsAndVaccinesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HospitalsTestsAndVaccinesContext() : base("name=HospitalsTestsAndVaccinesContext")
        {
        }

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Hospital> Hospitals { get; set; }

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<HospitalsTestsAndVaccines.Models.Order> Orders { get; set; }
    }
}
