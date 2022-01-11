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
    public class GetVehiclesHandler : IRequestHandler<GetVehiclesQuery, ICollection<VehicleDto>>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IMapper _mapper;
        
        public GetVehiclesHandler(IRepository<Vehicle> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<ICollection<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<VehicleDto>>(await _repository.GetAsync());
        }
    }
}