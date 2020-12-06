using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Controllers;
using WebApplication.Factories;
using WebApplication.Responses;

namespace WebApplication.Handlers
{
    public class AddAddressHandler : IRequestHandler<AddAddressCommand, AddAddressResponse>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        
        public AddAddressHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddAddressResponse> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request);
            
            await _repository.AddAsync(address);
            await _repository.SaveChangesAsync();

            return ResponseFactory.CreateSuccessResponse<AddAddressResponse>();
        }
    }
}