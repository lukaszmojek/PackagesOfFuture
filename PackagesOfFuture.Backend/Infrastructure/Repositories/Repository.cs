using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await this._dbSet
            .FindAsync(id);
    }

    public async Task<IReadOnlyCollection<T>> GetAsync()
    {
        return await this._dbSet
            .ToListAsync();
    }

    public async Task AddAsync(T resource)
    {
        await _dbSet.AddAsync(resource);
    }

    public async Task AddRangeAsync(IReadOnlyCollection<T> collection)
    {
        await _dbSet.AddRangeAsync(collection);
    }

    public void Delete(T resource)
    {
        _dbSet.Remove(resource);
    }

    public void DeleteRange(IReadOnlyCollection<T> collection)
    {
        _dbSet.RemoveRange(collection);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}