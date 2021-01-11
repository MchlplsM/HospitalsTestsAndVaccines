using HospitalsTestsAndVaccines.Core.Repositories;
using HospitalsTestsAndVaccines.Models;
using HospitalsTestsAndVaccines.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
        {
            private readonly ApplicationDbContext context;
            public AppointmentRepository(ApplicationDbContext context)
            {
                context = new ApplicationDbContext(); 
            }
            /// <summary>
            /// Get all appointments
            /// </summary>
            /// <returns></returns>
            public IEnumerable<Appointment> GetAppointments()
            {
                return context.Appointments
                    .Include(p => p.ApplicationUser)
                    .ToList();
            }
            /// <summary>
            /// Get appointments for single patient
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public IEnumerable<Appointment> GetAppointmentWithApplicationUser(string id)
            {
                return context.Appointments
                    .Where(p => p.ApplicationUserId == id)
                    .Include(p => p.ApplicationUser)
                    .ToList();
            }
            

           

            public IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel)
            {
                var result = context.Appointments.Include(p => p.ApplicationUser).AsQueryable();
                if (searchModel != null)
                {
                    if (!string.IsNullOrWhiteSpace(searchModel.Option))
                    {
                        if (searchModel.Option == "ThisMonth")
                        {
                            result = result.Where(x => x.StartDateTime.Year == DateTime.Now.Year && x.StartDateTime.Month == DateTime.Now.Month);
                        }
                        else if (searchModel.Option == "Pending")
                        {
                            result = result.Where(x => x.Status == false);
                        }
                        else if (searchModel.Option == "Approved")
                        {
                            result = result.Where(x => x.Status);
                        }
                    }
                }

                return result;

            }
            /// <summary>
            /// Get Daily appointments
            /// </summary>
            /// <param name="getDate"></param>
            /// <returns></returns>
            public IEnumerable<Appointment> GetDaillyAppointments(DateTime getDate)
            {
                return context.Appointments.Where(a => DbFunctions.DiffDays(a.StartDateTime, getDate) == 0)
                    .Include(p => p.ApplicationUser)
                    .ToList();
            }

            /// <summary>
            /// Validate appointment date and time
            /// </summary>
            /// <param name="appntDate"></param>
            /// <param name="id"></param>
            /// <returns></returns>
            public bool ValidateAppointment(DateTime appntDate)
            {
                return context.Appointments.Any(a => a.StartDateTime == appntDate);
            }
            /// <summary>
            /// Get number of appointments for defined patient
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public int CountAppointments(string id)
            {
                return context.Appointments.Count(a => a.ApplicationUserId == id);
            }


            /// <summary>
            /// Get single appointment
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public Appointment GetAppointment(int id)
            {
                return context.Appointments.Find(id);
            }

            public void Add(Appointment appointment)
            {
                context.Appointments.Add(appointment);
            }

    }
}