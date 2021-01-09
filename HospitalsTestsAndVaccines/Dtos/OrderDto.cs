using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Dtos
{
    public class OrderDto
    {
        public string UserId { get; set; }
        public List<string> ProductIds { get; set; }
    }
}