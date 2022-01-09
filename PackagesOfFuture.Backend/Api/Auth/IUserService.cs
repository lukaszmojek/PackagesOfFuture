using Data.Entities;

namespace Api.Auth
{
    public interface IUserService
    {
        string Authenticate(User user);
    }
}