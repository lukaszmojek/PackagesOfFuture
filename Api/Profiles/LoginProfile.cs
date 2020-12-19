using Api.Contracts;
using Api.Queries;
using AutoMapper;

namespace Api.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LogInDto, LogInQuery>();
        }
    }
}
