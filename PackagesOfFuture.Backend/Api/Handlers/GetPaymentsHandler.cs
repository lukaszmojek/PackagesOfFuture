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
    public class GetPaymentsHandler : IRequestHandler<GetPaymentsQuery, ICollection<PaymentDto>>
    {
        private readonly IRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public GetPaymentsHandler(IRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<PaymentDto>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<PaymentDto>>(await _repository.GetAsync());
        }
    }
}
