using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository<T>
    {
        public Task<T> GetById(int id);
    }
}