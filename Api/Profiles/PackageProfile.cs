using Api.Commands;
using AutoMapper;
using Contracts.Requests;
using Persistance.Entities;

namespace Api.Profiles
{
    public class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageDto>();

            CreateMap<RegisterPackageDto, RegisterPackageCommand>();
            
            CreateMap<PackageDetailsDto, Package>();
        }
    }
}