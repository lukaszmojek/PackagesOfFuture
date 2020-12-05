using AutoMapper;
using Persistance.Entities;
using WebApplication.Controllers;

namespace WebApplication.Profiles
{
    public class DroneProfile : Profile
    {
        public DroneProfile()
        {
            CreateMap<RegisterDroneDto, RegisterDroneCommand>();
            CreateMap<RegisterDroneCommand, Drone>();
            
            CreateMap<Drone, DroneDto>();
        }
    }
}