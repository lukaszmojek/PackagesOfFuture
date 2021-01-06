using Api.Commands;
using Contracts.Responses;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using Persistance.Entities;

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