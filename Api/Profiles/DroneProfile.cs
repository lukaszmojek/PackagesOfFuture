using Api.Commands;
using AutoMapper;
using Contracts.Dtos;
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

            CreateMap<Drone, DroneDto>()
                .ForMember(
                x => x.SortingName, 
                op => op.MapFrom(s => s.Sorting.Name));
        }
    }
}