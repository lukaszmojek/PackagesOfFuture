using Api.Commands;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;

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
            
            CreateMap<CreateAddressDto, Address>();
        }
    }
}