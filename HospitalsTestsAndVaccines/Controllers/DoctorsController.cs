using HospitalsTestsAndVaccines.Models;
using HospitalsTestsAndVaccines.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Net;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HospitalsTestsAndVaccines.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public DoctorsController()
        {

        }
        

        public ActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }
        DateTime today = DateTime.Now.Date;

        //Details for admin
        public ActionResult Details(string id)
        {
            var viewModel = new DoctorDetailViewModel
            {
                //GetDoctor
                Doctor = _context.Doctors
                .SingleOrDefault(d => d.Id == id),

                //UpcomingAppointments = _unitOfWork.Appointments.GetTodaysAppointments(id),

                UpcomingAppointments = _context.Appointments
                .Where(d => d.Doctor.ApplicationUserId == id && d.StartDateTime >= today && d.Status == true)
                .Include(p => p.ApplicationUser)
                .OrderBy(d => d.StartDateTime)
                .ToList(),
                // GetAppointmentByDoctor
                Appointments = _context.Appointments
                .Where(p => p.ApplicationUserId == id)
                .Include(p => p.ApplicationUser)
                .Include(d => d.Doctor)
                .ToList()
            };
            return View(viewModel);
        }

        public ActionResult DoctorProfile()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new DoctorDetailViewModel
            {
                Doctor = _context.Doctors
                .SingleOrDefault(d => d.ApplicationUserId == userId),
                //UpcomingAppointments
                Appointments = _context.Appointments
                .Where(d => d.Doctor.ApplicationUserId == userId && d.StartDateTime >= today && d.Status == true)
                .Include(p => p.ApplicationUser)
                .OrderBy(d => d.StartDateTime)
                .ToList(),
            };
            return View(viewModel);
        }
        //public ActionResult Edit(string id)
        //{
        //    var doctor = _unitOfWork.Doctors.GetDoctor(id);
        //    if (doctor == null) return HttpNotFound();
        //    var viewModel = new DoctorFormViewModel()
        //    {

        //        Id = doctor.Id,
        //        Name = doctor.Name,
        //        Phone = doctor.Phone,
        //        Address = doctor.Address,
        //        IsAvailable = doctor.IsAvailable,


        //    };
        //    return View(viewModel);
        //}

        //[HttpPost]
        //public ActionResult Edit(DoctorFormViewModel viewModel)
        //{


        //    var doctorInDb = _unitOfWork.Doctors.GetDoctor(viewModel.Id);
        //    doctorInDb.Id = viewModel.Id;
        //    doctorInDb.Name = viewModel.Name;
        //    doctorInDb.Phone = viewModel.Phone;
        //    doctorInDb.Address = viewModel.Address;
        //    doctorInDb.IsAvailable = viewModel.IsAvailable;

        //    _unitOfWork.Complete();

        //    return RedirectToAction("Details", new { id = viewModel.Id });
        //}


    }

}