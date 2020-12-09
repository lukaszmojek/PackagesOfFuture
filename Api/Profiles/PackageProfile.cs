using Api.Contracts;
using AutoMapper;
using Persistance.Entities;
using WebApplication.Contracts;

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