using Api.Commands;
using Api.Controllers;
using AutoMapper;
using Contracts.Requests;
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
    
    public class SupportIssueProfile : Profile
    {
        public SupportIssueProfile()
        {
            CreateMap<SupportIssue, SupportIssueDto>();
            
            CreateMap<RegisterSupportIssueDto, RegisterSupportIssueCommand>();
            CreateMap<RegisterSupportIssueCommand, SupportIssue>();
        }
    }
}