using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Contracts;
using Api.Queries;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using Api.Controllers;

namespace Api.Handlers
{
    public class GetDronesHandler : IRequestHandler<GetDronesQuery, ICollection<DroneDto>>
    {
        private IRepository<Drone> _repository;
        private IMapper _mapper;

        public GetDronesHandler(IRepository<Drone> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<DroneDto>> Handle(GetDronesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<DroneDto>>(await _repository.GetAsync());
        }
    }
}