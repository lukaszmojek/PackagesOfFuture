using Api.Commands;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;

namespace Api.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDto>();
            
            CreateMap<RegisterServiceDto, RegisterServiceCommand>();
            CreateMap<RegisterServiceCommand, Service>();
        }
    }
}