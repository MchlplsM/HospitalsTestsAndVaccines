using AutoMapper;
using HospitalsTestsAndVaccines.Dtos;
using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HospitalsTestsAndVaccines.Controllers
{
    public class AppUserController : ApiController
    {
        private ApplicationDbContext context;

        public AppUserController()
        {
            context = new ApplicationDbContext();
        }
        //Get /api/users
        public IEnumerable<ApplicationUserDto> GetUsers()
        {
            return context.Users.ToList().Select(Mapper.Map<ApplicationUser, ApplicationUserDto>);
        }


        //GEt /api/user/1
        public IHttpActionResult GetUser(string id)
        {
            var user = context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<ApplicationUser, ApplicationUserDto>(user));
        }

        //Post /api/user
        [HttpPost]
        public IHttpActionResult CreateUser(ApplicationUserDto applicationUserDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var user = Mapper.Map<ApplicationUserDto, ApplicationUser>(applicationUserDto);
            context.Users.Add(user);
            context.SaveChanges();

            applicationUserDto.Id = user.Id;
            return Created(new Uri(Request.RequestUri + "/" + user.Id), applicationUserDto);
        }

        //put /api/user/1
        [HttpPut]
        public IHttpActionResult UpdateUser(string id, ApplicationUserDto applicationUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userInDb = context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                return NotFound();

            Mapper.Map(applicationUserDto, userInDb);


            context.SaveChanges();

            return Ok();

        }


        // DELETE /api/users/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(string id)
        {
            var userInDb = context.Users.SingleOrDefault(c => c.Id == id);

            if (userInDb == null)
                return NotFound();

            context.Users.Remove(userInDb);
            context.SaveChanges();

            return Ok();
        }
    }
}

