using Api.Commands;
using Api.Controllers;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;

namespace Api.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>();
            
            CreateMap<RegisterVehicleDto, RegisterVehicleCommand>();
            CreateMap<RegisterVehicleCommand, Vehicle>();
        }
    }
}