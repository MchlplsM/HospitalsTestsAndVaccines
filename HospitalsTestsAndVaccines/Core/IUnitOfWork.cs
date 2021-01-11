using HospitalsTestsAndVaccines.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalsTestsAndVaccines.Core
{
    public interface IUnitOfWork
    {
        //IPatientRepository Patients { get; }
        IApplicationUserRepository ApplicationUsers { get; }
        IAppointmentRepository Appointments { get; }
        //IAttendanceRepository Attandences { get; }
        //ICityRepository Cities { get; }
        //IDoctorRepository Doctors { get; }
        //ISpecializationRepository Specializations { get; }
        //IApplicationUserRepository Users { get; }

        void Complete();
    }
}
