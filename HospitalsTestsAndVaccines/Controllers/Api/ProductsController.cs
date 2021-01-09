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
    public class ProductsController : ApiController
    {
        private ApplicationDbContext context;

        public ProductsController()
        {
            context = new ApplicationDbContext();
        }
        //Get /api/products
        public IEnumerable<ProductDto> GetProducts(string query = null)
        {
            var productsQuery = context.Products
                .Where(p => p.NumberAvailable > 0); 

            if (!String.IsNullOrWhiteSpace(query))
                productsQuery = productsQuery.Where(p => p.ProductName.Contains(query));

            return productsQuery
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);
        }


        //GEt /api/products/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = context.Products.SingleOrDefault(u => u.Id == id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        //Post /api/products
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var product = Mapper.Map<ProductDto, Product>(productDto);
            context.Products.Add(product);
            context.SaveChanges();

            productDto.Id = product.Id;
            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }

        //put /api/products/1
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = context.Products.SingleOrDefault(u => u.Id == id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDto, productInDb);


            context.SaveChanges();

            return Ok();

        }


        // DELETE /api/products/1
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var prodcutInDb = context.Products.SingleOrDefault(c => c.Id == id);

            if (prodcutInDb == null)
                return NotFound();

            context.Products.Remove(prodcutInDb);
            context.SaveChanges();

            return Ok();
        }
    }
}


