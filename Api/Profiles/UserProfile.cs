using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Persistance.Entities;
using WebApplication.Commands;
using WebApplication.Contracts;
using WebApplication.Controllers;
using WebApplication.Queries;
using WebApplication.Responses;

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

            CreateMap<LogInDto, LogInQuery>();
            CreateMap<User, LogInResponse>();

            CreateMap<User, UserDto>();
        }
    }
}