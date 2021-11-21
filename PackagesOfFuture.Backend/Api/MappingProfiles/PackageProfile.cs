using Api.Commands;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;

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