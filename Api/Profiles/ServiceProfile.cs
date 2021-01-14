using Api.Commands;
using Api.Controllers;
using Api.Handlers;
using AutoMapper;
using Contracts.Requests;
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