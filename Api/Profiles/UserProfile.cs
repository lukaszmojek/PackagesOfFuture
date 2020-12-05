using AutoMapper;
using Persistance.Entities;
using WebApplication.Commands;

namespace WebApplication.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, RegisterUser>();
            CreateMap<RegisterUser, User>();
        }
    }

    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}