using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Persistance.Entities;
using WebApplication.Queries;

namespace WebApplication.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageDto>();
        }
    }
}