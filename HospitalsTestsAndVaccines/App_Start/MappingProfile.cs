using AutoMapper;
using HospitalsTestsAndVaccines.Dtos;
using HospitalsTestsAndVaccines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, ApplicationUserDto>();

            Mapper.CreateMap<ApplicationUserDto, ApplicationUser>();

            Mapper.CreateMap<Product, ProductDto>();

            Mapper.CreateMap<ProductDto, Product>();
        }
    }
}