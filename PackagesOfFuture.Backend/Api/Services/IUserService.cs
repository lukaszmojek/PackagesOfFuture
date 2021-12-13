using System.Collections.Generic;
using Contracts.Dtos;
using Contracts.Responses;
using Data.Entities;

namespace Api.Services
{
    public interface IUserService
    {
        string Authenticate(User user);
        // IEnumerable<User> GetAll();
        // User GetById(int id);
    }
}