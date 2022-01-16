using System;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public async Task<Address> GetAddressByUserId(int userId)
    {
        var user = await _dbSet.Include(x => x.Address)
            .SingleOrDefaultAsync(x => x.Id == userId) ?? throw new Exception("User does not exists");

        return user.Address;
    }

    public async Task<User> GetUserById(int userId)
    {
        var user = await _dbSet.Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
        {
            throw new Exception("User does not exists");
        }

        return user;
    }
}