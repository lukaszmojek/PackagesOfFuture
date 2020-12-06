using AutoMapper;
using Persistance.Entities;
using WebApplication.Contracts;
using WebApplication.Controllers;

namespace WebApplication.Profiles
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