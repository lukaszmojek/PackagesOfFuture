using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public interface IRepository<T>
{
    public Task<T> GetByIdAsync(int id);

    public Task<IReadOnlyCollection<T>> GetAsync();

    public Task AddAsync(T resource);

    public Task AddRangeAsync(IReadOnlyCollection<T> collection);

    public void Delete(T resource);
    public void DeleteRange(IReadOnlyCollection<T> collection);

    public Task SaveChangesAsync();
}