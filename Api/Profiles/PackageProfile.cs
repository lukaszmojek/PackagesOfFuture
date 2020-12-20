using Contracts;
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
        }
    }
}