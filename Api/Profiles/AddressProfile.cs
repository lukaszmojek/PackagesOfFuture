using AutoMapper;
using Persistance.Entities;
using WebApplication.Controllers;
using Api.Contracts;
using WebApplication.Contracts;

namespace WebApplication.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddAddressDto, AddAddressCommand>();
            CreateMap<AddAddressCommand, Address>();
            
            CreateMap<Address, AddressDto>();
        }
    }
}