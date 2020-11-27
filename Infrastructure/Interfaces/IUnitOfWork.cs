using Persistance.Entities;

namespace Infrastructure
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}