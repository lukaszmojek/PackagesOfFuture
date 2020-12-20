using Api.Commands;
using Contracts;
using Api.Controllers;
using AutoMapper;
using Contracts.Requests;
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