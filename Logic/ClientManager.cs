using System.Threading.Tasks;
using Data.Entities;
using Infrastructure;

namespace Logic
{
    public class ClientManager
    {
        private Repository<User> repository;

        public ClientManager(Repository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> ClientExistsAsync(int clientId)
        {
            var client = await this.repository.GetByIdAsync(clientId).ConfigureAwait(false);

            return client != null;
        }
    }
}
