using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this._dbSet
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<T>> GetAsync()
        {
            return await this._dbSet
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task AddAsync(T resource)
        {
            await _dbSet.AddAsync(resource);
        }

        public async Task AddRangeAsync(IReadOnlyCollection<T> collection)
        {
            await _dbSet.AddRangeAsync(collection);
        }
        
        public void DeleteAsync(T resource)
        {
            _dbSet.Remove(resource);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}