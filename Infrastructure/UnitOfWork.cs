using System;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        
        public UnitOfWork(IRepository<User> clientRepository, IRepository<Address> addressRepository, DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
