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
        ApplicationDbContext _context = new ApplicationDbContext();
        public AppointmentsController()
        {

        }

        //--------------------------------Show only 1 patient's appointments NOT EVERYONES
        public ActionResult AppointmentsOfPatient() 
        {
            var appointments = _context.Appointments
                .Include(p => p.ApplicationUser)
                .Include(p => p.Product)
                .ToList();
            return View(appointments);
        }

        //--------------------------------Show all patients appointments
        public ActionResult AllAppointments() 
        {
            var appointments = _context.Appointments
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
                Products = _context.Products.ToList(),
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
                ApplicationUser = _context.Users.SingleOrDefault(p => p.Id == currentlyLoggedInUserId),
                Product = _context.Products.SingleOrDefault(p => p.Id == viewModel.Product)
            };
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return RedirectToAction("AppointmentsOfPatient", "Appointments");
        }


        public ActionResult Edit(int id)
        {
            var appointment = _context.Appointments.Find(id);
            var viewModel = new AppointmentFormViewModel()
            {
                Heading = "New Appointment",
                Id = appointment.Id,
                Date = appointment.StartDateTime.ToString("dd/MM/yyyy"),
                Time = appointment.StartDateTime.ToString("HH:mm"),
                Detail = appointment.Detail,
                Status = appointment.Status,
                ApplicationUser = appointment.ApplicationUserId,
                //Patients = _unitOfWork.Patients.GetPatients(),
                //Doctors = _context.Doctors.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppointmentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //viewModel.Doctors = _context.Doctors.ToList();
                viewModel.ApplicationUsers = _context.Users.ToList();
                return View(viewModel);
            }

            var appointmentInDb = _context.Appointments.Find(viewModel.Id);
            appointmentInDb.Id = viewModel.Id;
            appointmentInDb.StartDateTime = viewModel.GetStartDateTime();
            appointmentInDb.Detail = viewModel.Detail;
            appointmentInDb.Status = viewModel.Status;
            appointmentInDb.ApplicationUserId = viewModel.ApplicationUser;
            //appointmentInDb.DoctorId = viewModel.Doctor;

            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        public PartialViewResult GetUpcommingAppointments()
        {
            DateTime today = DateTime.Now.Date;

            var appointments = _context.Appointments
                .Where(/*d => d.DoctorId == id && */d => d.StartDateTime >= today)
                .Include(p => p.ApplicationUser)
                .OrderBy(d => d.StartDateTime)
                .ToList();
            return PartialView(appointments);
        }
    }
}
