using Api.Queries;
using AutoMapper;
using Contracts.Dtos;

namespace Api.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<AuthenticateUserDto, AuthenticateUserQuery>();
        }
    }
}
