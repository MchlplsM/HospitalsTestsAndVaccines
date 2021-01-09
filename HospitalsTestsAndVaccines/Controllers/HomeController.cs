using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalsTestsAndVaccines.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //------------------------------
        //public  JsonResult GetEvents()
        //{
        //    var events = db.Events.ToList();
        //    return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}
        //[HttpPost]
        //public JsonResult SaveEvent(Event e)
        //{
        //    var status = false;
        //    if (e.EventID > 0)
        //    {
        //        //Update the event
        //        var v = db.Events.Where(a => a.Event == e.EventID).FirstOfDefault();
        //        if (v != null)
        //        {
        //            v.Subject = e.Subject;
        //            v.Start = e.Start;
        //            v.End = e.End;
        //            v.Description = e.Description;
        //            v.IsFullDay = e.IsFullDay;
        //            v.ThemeColor = e.ThemeColor;
        //        }
        //    }
        //    else
        //    {
        //        db.Events.Add(e);
        //    }
        //    db.SaveChanges();
        //    status = true;
        //    return new JsonResult { Data = new { status = status } };
        //}
        //[HttpPost]
        //public JsonResult DeleteEvent(int eventID)
        //{
        //    var status = false;
        //    var v = db.Events.Where(a => a.EventId == eventID).FirstOfDefault();
        //    if (v != null)
        //    {
        //        db.Events.Remove(v);
        //        db.SaveChanges();
        //        status = true;
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}

    }
}