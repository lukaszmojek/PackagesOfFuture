using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using AutoMapper;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class AddAddressHandler : IRequestHandler<AddAddressCommand, Response<AddAddressResponse>>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        
        public AddAddressHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<AddAddressResponse>> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request);
            
            await _repository.AddAsync(address);
            await _repository.SaveChangesAsync();

            return ResponseFactory.CreateSuccessResponse<AddAddressResponse>();
        }
    }
}