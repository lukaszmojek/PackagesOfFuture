using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Api.Handlers
{
    public class GetAddressesHandler : IRequestHandler<GetAddressesQuery, ICollection<AddressDto>>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        
        public GetAddressesHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<AddressDto>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<AddressDto>>(await _repository.GetAsync());
        }
    }
}