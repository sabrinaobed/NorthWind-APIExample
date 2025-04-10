﻿using AutoMapper;
using NorthWind_APIExample.Models;
using NorthWind_APIExample.Dto;

namespace NorthWind_APIExample.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
        }
    }
}
