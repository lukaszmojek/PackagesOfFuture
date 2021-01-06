using Api.Queries;
using AutoMapper;
using Contracts.Requests;

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
