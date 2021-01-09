using HospitalsTestsAndVaccines.Models;
using HospitalsTestsAndVaccines.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalsTestsAndVaccines.Core.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointments();//GOT THIS
        IEnumerable<Appointment> GetAppointmentWithApplicationUser(int id); //MAYBE NEEDS STRING //GOT THIS
        IEnumerable<Appointment> GetDaillyAppointments(DateTime getDate); //GOT THIS
        IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel);
        bool ValidateAppointment(DateTime appntDate); //GOT THIS
        int CountAppointments(int id); //GOT THIS
        Appointment GetAppointment(int id); //GOT THIS
        void Add(Appointment appointment); //GOT THIS

    }
}
