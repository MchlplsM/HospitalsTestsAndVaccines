using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalsTestsAndVaccines.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetApplicationUsers();
        IEnumerable<ApplicationUser> GetRecentApplicationUsers();
        //IEnumerable<Patient> GetPatientByToken(string searchTerm = null);
        ApplicationUser GetApplicationUser(string id);
        //IQueryable<Patient> GetPatientQuery(string query);
        void Add(ApplicationUser applicationUser);
        void Remove(ApplicationUser applicationUser);
    }
}
