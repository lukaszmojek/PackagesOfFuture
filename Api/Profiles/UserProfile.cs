using AutoMapper;
using Persistance.Entities;
using WebApplication.Commands;
using WebApplication.Controllers;

namespace WebApplication.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, RegisterUserCommand>();
            CreateMap<RegisterUserCommand, User>();

            CreateMap<ChangeUserDetailsDto, ChangeUserDetailsCommand>();
            CreateMap<ChangeUserDetailsCommand, User>();
        }
    }
}