using Api.Commands;
using AutoMapper;
using Contracts.Requests;
using Data.Entities;

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