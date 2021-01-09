using AutoMapper;
using HospitalsTestsAndVaccines.Dtos;
using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HospitalsTestsAndVaccines.Controllers.Api
{
    public class NewOrdersController : ApiController
    {
        private ApplicationDbContext db;

        public NewOrdersController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewOrder(OrderDto newOrder)
        {
            var user = db.Users.Single(
                c => c.Id == newOrder.UserId);

            var products = db.Products.Where(
                p => newOrder.ProductIds.Contains(p.Id.ToString())).ToList();

            foreach (var product in products)
            {
                if (product.NumberAvailable == 0)
                    return BadRequest("Product is not available.");

                product.NumberAvailable--;

                var order = new Order
                {
                    User = user,
                    Product = product,
                    OrderDate = DateTime.Now
                };

                db.Orders.Add(order);
            }

            db.SaveChanges();

            return Ok();
        }
    }
}