using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private DbSet<T> dbSet { get; }

        public Repository(DbContext context)
        {
            this.dbSet = context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await this.dbSet
                .FindAsync(id)
                .ConfigureAwait(false);
        }
    }
}