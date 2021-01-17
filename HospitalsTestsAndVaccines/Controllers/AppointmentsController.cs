using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalsTestsAndVaccines.Core;
using HospitalsTestsAndVaccines.Models;
using HospitalsTestsAndVaccines.ViewModels;

namespace HospitalsTestsAndVaccines.Controllers
{
    public class AppointmentsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public AppointmentsController()
        {

        }

        //--------------------------------Show only 1 patient's appointments NOT EVERYONES
        public ActionResult AppointmentsOfPatient() 
        {
            var appointments = context.Appointments
                .Include(p => p.ApplicationUser)
                .Include(p => p.Product)
                .ToList();
            return View(appointments);
        }

        //--------------------------------Show all patients appointments
        [Authorize(Roles = "HospAdmin")]
        public ActionResult AllAppointments() 
        {
            var appointments = context.Appointments
                .Include(p => p.ApplicationUser)
                .Include(p => p.Product)
                .ToList();
            return View(appointments);
        }

        //--------------------------------ONLY PATIENT can create an appointment
        [Authorize(Roles = "Patient")]
        public ActionResult Create(string id)
        {
            var viewModel = new AppointmentFormViewModel
            {
                 ApplicationUser = id,
                Products = context.Products.ToList(),
                Heading = "New Appointment"
                //ApplicationUsers = _context.ApplicationUsers.ToList(),
                // AvailableDoctor
                //Doctors = _context.Doctors
                //.Where(a => a.IsAvailable == true)
                //.ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Patient")]
        public ActionResult Create(AppointmentFormViewModel viewModel)
        {
            var currentlyLoggedInUserId = (((System.Security.Claims.ClaimsPrincipal)System.Web.HttpContext.Current.User).Claims).ToList()[0].Value;
            var appointment = new Appointment()
            {
                StartDateTime = viewModel.GetStartDateTime(),
                Detail = viewModel.Detail,
                Status = false,
                ApplicationUser = context.Users.SingleOrDefault(p => p.Id == currentlyLoggedInUserId),
                Product = context.Products.SingleOrDefault(p => p.Id == viewModel.Product)
            };
            context.Appointments.Add(appointment);
            context.SaveChanges();
            return RedirectToAction("AppointmentsOfPatient", "Appointments");
        }

        //--------------------------------ONLY HospADMIN can edit the Appointment -> Accept/Decline an appointment
        public ActionResult Edit(int id)
        {
            var appointment = context.Appointments.SingleOrDefault(p => p.Id == id);
            //OR
            //var appointment = context.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Appointment appointment)
        {
            var appointmentInDb = context.Appointments.Find(appointment.Id);
            appointmentInDb.Id = appointment.Id;
            appointmentInDb.StartDateTime = appointment.StartDateTime;
            appointmentInDb.Detail = appointment.Detail;
            appointmentInDb.Status = appointment.Status;
            appointmentInDb.ApplicationUserId = appointment.ApplicationUserId;
            context.SaveChanges();
            return RedirectToAction("AllAppointments");
        }

        //var appointment = new Appointment()
        //{
        //    StartDateTime = viewModel,
        //    Detail = viewModel.Detail,
        //    Status = false,
        //    ApplicationUser = context.Users.SingleOrDefault(p => p.Id == viewModel.ApplicationUser),
        //    Product = context.Products.SingleOrDefault(p => p.Id == viewModel.Product)
        //};
        //context.Appointments.Add(appointment);
        //    context.SaveChanges();
        //    return RedirectToAction("AppointmentsOfPatient", "Appointments");


        public PartialViewResult GetUpcommingAppointments()
        {
            DateTime today = DateTime.Now.Date;

            var appointments = context.Appointments
                .Where(/*d => d.DoctorId == id && */d => d.StartDateTime >= today)
                .Include(p => p.ApplicationUser)
                .OrderBy(d => d.StartDateTime)
                .ToList();
            return PartialView(appointments);
        }
    }
}
