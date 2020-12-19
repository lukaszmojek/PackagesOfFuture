using Api.Commands;
using AutoMapper;
using Persistance.Entities;
using Api.Contracts;
using Api.Controllers;

namespace Api.Profiles
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