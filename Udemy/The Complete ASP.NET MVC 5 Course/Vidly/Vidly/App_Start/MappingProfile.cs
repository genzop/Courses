﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Registra las diferentes formas de mapeo
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());    //Ignorar el Id durante el mapeo de MovieDto a Movie
            Mapper.CreateMap<Movie, MovieDto>();            
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());          //Ignorar el Id durante el mapeo de MovieDto a Movie
        }
    }
}