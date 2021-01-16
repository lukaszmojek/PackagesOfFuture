using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class GetServicesHandler : IRequestHandler<GetServicesQuery, ICollection<ServiceDto>>
    {
        private IRepository<Service> _repository;
        private IMapper _mapper;
        
        public GetServicesHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<ICollection<ServiceDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<ServiceDto>>(await _repository.GetAsync());
        }
    }
}