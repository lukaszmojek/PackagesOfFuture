using System;
using Persistance.Entities;

namespace Infrastructure
{
    public class UnitOfWork
    {
        public IRepository<Client> ClientRepository;
        public IRepository<Address> AddressRepository;

        public UnitOfWork(IRepository<Client> clientRepository, IRepository<Address> addressRepository)
        {
            ClientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            AddressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }
    }
}
