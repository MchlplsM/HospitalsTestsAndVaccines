using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalsTestsAndVaccines.Models;

namespace HospitalsTestsAndVaccines.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult New()
        {
            return View();
        }
    }
}
