using System.Threading.Tasks;
using Data.Entities;

namespace Infrastructure.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<Address> GetAddressByUserId(int userId);
}