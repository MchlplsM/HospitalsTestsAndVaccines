using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalsTestsAndVaccines.Models;
using HospitalsTestsAndVaccines.ViewModels;

namespace HospitalsTestsAndVaccines.Controllers
{
    public class ApplicationUsersController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext context;
        public ApplicationUsersController()
        {
            context = new ApplicationDbContext();
        }
        // GET: ApplicationUsers
        [Authorize(Roles = "Devs, HospAdmin")]
        public ActionResult ListOfCustomers(string option, string search) //ONLY DEVS WILL SEE
        {
            //var context = new ApplicationDbContext();
            //var users = context.Users.ToList();
            if (option == "FirstName")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(context.Users.Where(x => x.FirstName.Contains(search) || search == null).ToList());
            }
            else if (option == "LastName")
            {
                return View(context.Users.Where(x => x.LastName.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(context.Users.Where(x => x.Phone.Contains(search) || search == null).ToList());
            }

            //return View(users);
        }

        ds
        [Authorize]
        public ActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        //// GET: ApplicationUsers
        //public ActionResult ListOfCustomers() //ONLY DEVS WILL SEEd
        //{
        //    var users = context.Users.ToList();
        //    return View(users);
        //}
        public ActionResult ReadAndEditOnly()
        {
            var currentlyLoggedInUserId = (((System.Security.Claims.ClaimsPrincipal)System.Web.HttpContext.Current.User).Claims).ToList()[0].Value;
            var context = new ApplicationDbContext();
            var users = context.Users.Single(e => e.Id == currentlyLoggedInUserId);
            return View(users);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = context.Users.SingleOrDefault(c => c.Id == id);
            if (person == null)
                return HttpNotFound();
            return View(person);

        }

        public ActionResult Edit(string id)
        {
            var person = context.Users.SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Phone,Amka,DateOfBirth,HealthIssues,Address,City,PostalCode,State,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                context.Entry(applicationUser).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("UsersWithRoles");
            }
            return View(applicationUser);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = context.Users.SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var person = context.Users.SingleOrDefault(p => p.Id == id);
            context.Users.Remove(person);
            context.SaveChanges();
            return RedirectToAction("UsersWithRoles");
        }




        public ActionResult UsersWithRoles()
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new Users_in_Role_ViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });


            return View(usersWithRoles);
        }
    }
}
