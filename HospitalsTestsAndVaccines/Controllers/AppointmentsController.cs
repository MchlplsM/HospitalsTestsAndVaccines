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
        // GET: Appointments
        public ActionResult Index()
        {
            //GetAppointments
            var appointments = _context.Appointments
                .Include(p => p.ApplicationUser)
                .Include(p => p.Product)
                .ToList();
            return View(appointments);
        }
        public ActionResult Details(string id)
        {
            var appointment = _context.Appointments
                .Where(p => p.ApplicationUserId == id)
                .Include(p => p.ApplicationUser)
                .ToList();
            return View("_AppointmentPartial", appointment);
        }

        public ActionResult Create(string id)
        {
            var viewModel = new AppointmentFormViewModel
            {
                ApplicationUser = id,
                //ApplicationUsers = _context.ApplicationUsers.ToList(),
                Products = _context.Products.ToList(),
                // AvailableDoctor
                //Doctors = _context.Doctors
                //.Where(a => a.IsAvailable == true)
                //.ToList(),

                Heading = "New Appointment"
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentFormViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    // AvailableDoctor
            //    viewModel.Doctors = _context.Doctors
            //    .Where(a => a.IsAvailable == true)
            //    .ToList();
            //    return View(viewModel);

            //}
            var appointment = new Appointment()
            {
                StartDateTime = viewModel.GetStartDateTime(),
                Detail = viewModel.Detail,
                Status = true,
                ApplicationUserId = viewModel.ApplicationUser,
                Product = _context.Products.SingleOrDefault(p => p.Id.ToString() == viewModel.Product),
                //Doctor = _context.Doctors.SingleOrDefault(d => d.Id == viewModel.Doctor)
                //Doctor = _unitOfWork.Doctors.GetDoctor(viewModel.Doctor)


            };
            //Check if the slot is available
            //if (_unitOfWork.Appointments.ValidateAppointment(appointment.StartDateTime))
            //if (_context.Appointments.Any(a => a.StartDateTime == appntDate && a.DoctorId == id))
            // return View("InvalidAppointment");

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return RedirectToAction("Index", "Appointments");
        }


        public ActionResult Edit(string id)
        {
            var appointment = _context.Appointments.Find(id);
            var viewModel = new AppointmentFormViewModel()
            {
                Heading = "New Appointment",
                Id = appointment.Id.ToString(),
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
            appointmentInDb.Id = Convert.ToInt32(viewModel.Id);
            appointmentInDb.StartDateTime = viewModel.GetStartDateTime();
            appointmentInDb.Detail = viewModel.Detail;
            appointmentInDb.Status = viewModel.Status;
            appointmentInDb.ApplicationUserId = viewModel.ApplicationUser;
            //appointmentInDb.DoctorId = viewModel.Doctor;

            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        public PartialViewResult GetUpcommingAppointments(string id)
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
