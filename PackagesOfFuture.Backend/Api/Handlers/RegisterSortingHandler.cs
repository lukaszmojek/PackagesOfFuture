using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Factories;
using AutoMapper;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Api.Handlers
{
    public class RegisterSortingHandler : IRequestHandler<RegisterSortingCommand, Response<RegisterSortingResponse>>
    {
        private IRepository<Sorting> _sortingRepository;
        private IRepository<Address> _addressRepository;
        private IMapper _mapper;

        public RegisterSortingHandler(IMapper mapper, IRepository<Address> addressRepository, IRepository<Sorting> sortingRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _sortingRepository = sortingRepository;
        }
        
        public async Task<Response<RegisterSortingResponse>> Handle(RegisterSortingCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request.Address);

            var sorting = _mapper.Map<Sorting>(request);
            await _sortingRepository.AddAsync(sorting);
            await _sortingRepository.SaveChangesAsync();

            return ResponseFactory.CreateSuccessResponse<RegisterSortingResponse>();
        }
    }
}