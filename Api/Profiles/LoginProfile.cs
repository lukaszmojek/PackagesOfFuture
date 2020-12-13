using Api.Contracts;
using AutoMapper;
using WebApplication.Queries;

namespace WebApplication.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LogInDto, LogInQuery>();
        }
    }
}
