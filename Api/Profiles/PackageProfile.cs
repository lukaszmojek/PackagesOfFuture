using Api.Contracts;
using AutoMapper;
using Persistance.Entities;

namespace Api.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageDto>();
        }
    }
}