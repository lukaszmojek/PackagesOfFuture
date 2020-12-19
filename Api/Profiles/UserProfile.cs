using System.Collections;
using System.Collections.Generic;
using Api.Commands;
using Api.Contracts;
using Api.Controllers;
using Api.Queries;
using AutoMapper;
using Persistance.Entities;
using Api.Responses;

namespace Api.Profiles
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