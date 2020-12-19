using Api.Commands;
using Api.Contracts;
using Api.Controllers;
using AutoMapper;
using Persistance.Entities;

namespace Api.Profiles
{
    public class DroneProfile : Profile
    {
        public DroneProfile()
        {
            CreateMap<RegisterDroneDto, RegisterDroneCommand>();
            CreateMap<RegisterDroneCommand, Drone>();

            CreateMap<MoveDroneToSortingDto, MoveDroneToSortingCommand>();
            
            CreateMap<Drone, DroneDto>();
        }
    }
}