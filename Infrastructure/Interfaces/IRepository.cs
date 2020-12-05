using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository<T>
    {
        public Task<T> GetByIdAsync(int id);
        
        public Task<IReadOnlyCollection<T>> GetAsync();
        
        public Task AddAsync(T resource);
        
        public Task AddRangeAsync(IReadOnlyCollection<T> collection);

        public void DeleteAsync(T resource);

        public Task SaveChangesAsync();
    }
}