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
        private ApplicationDbContext context;
        public ApplicationUsersController()
        {
            context = new ApplicationDbContext();
        }

        //-----------------------------------A LIST OF ALL THE CUSTOMERS FOR DEVS AND ADMINS
        [Authorize(Roles = "HospAdmin")]
        public ActionResult ListOfCustomers(string option, string search) //ONLY Admins and Devs WILL SEE
        {
            if (option == "FirstName")
            {
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
        }

        //-----------------------------------THE PATIENT'S PROFILE
        public ActionResult ReadAndEditOnly()
        {
            var currentlyLoggedInUserId = (((System.Security.Claims.ClaimsPrincipal)System.Web.HttpContext.Current.User).Claims).ToList()[0].Value;
            var context = new ApplicationDbContext();
            var users = context.Users.Single(e => e.Id == currentlyLoggedInUserId);
            return View(users);
        }

        //-----------------------------------DEVS AND ADMINS CAN SEE THE PATIENTS PROFILES IN DETAIL
        [Authorize(Roles = "Dev, HospAdmin")]
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

        //-----------------------------------ONLY THE PATIENT AND THE ADMINS CAN ALTER THE PROFILE
        [Authorize(Roles = "Patient, HospAdmin")]
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
        [Authorize(Roles = "Patient, HospAdmin")]
        public ActionResult Edit(ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                context.Entry(applicationUser).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ReadAndEditOnly");
            }
            return View(applicationUser);
        }

        //-----------------------------------ONLY THE ADMIN CAN DELETE A PROFILE, UPON REQUEST
        [Authorize(Roles = "HospAdmin")]
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
        [Authorize(Roles = "HospAdmin")]
        public ActionResult DeleteConfirmed(string id)
        {
            var person = context.Users.SingleOrDefault(p => p.Id == id);
            context.Users.Remove(person);
            context.SaveChanges();
            return RedirectToAction("UsersWithRoles");
        }

        //-----------------------------------ONLY THE DEV CAN CHECK THE ROLES
        [Authorize(Roles = "Dev")]
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
