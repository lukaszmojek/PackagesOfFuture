using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Persistance.Entities;

namespace Logic
{
    public class ClientManager
    {
        private Repository<Client> repository;

        public ClientManager(Repository<Client> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> ClientExistsAsync(int clientId)
        {
            var client = await this.repository.GetById(clientId).ConfigureAwait(false);

            return client != null;
        }
    }
}
