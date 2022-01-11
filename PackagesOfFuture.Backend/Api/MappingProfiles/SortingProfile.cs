using Api.Commands;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;

namespace Api.Profiles
{
    public class SortingProfile : Profile
    {
        public SortingProfile()
        {
            CreateMap<RegisterSortingDto, RegisterSortingCommand>();
            CreateMap<RegisterSortingCommand, Sorting>();
            
            CreateMap<Sorting, SortingDto>();
            
            CreateMap<ChangeSortingDetailsDto, ChangeSortingDetailsCommand>();
        }
    }
}