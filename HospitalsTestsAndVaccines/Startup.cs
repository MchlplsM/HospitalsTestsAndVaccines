using AutoMapper;
//using HospitalsTestsAndVaccines.Migrations;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalsTestsAndVaccines.Startup))]
namespace HospitalsTestsAndVaccines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
