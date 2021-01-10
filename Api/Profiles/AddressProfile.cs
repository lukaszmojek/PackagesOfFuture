using Api.Commands;
using AutoMapper;
using Persistance.Entities;
using Contracts.Requests;

namespace Api.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddAddressDto, AddAddressCommand>();
            CreateMap<AddAddressCommand, Address>();
            
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
        }
    }
}