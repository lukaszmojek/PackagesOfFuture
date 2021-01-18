using Api.Commands;
using Api.Controllers;
using Contracts.Responses;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;

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

            CreateMap<ChangeUserPasswordDto, ChangeUserPasswordCommand>();
        }
    }
}