using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Factories;
using AutoMapper;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class ChangeSortingDetailsHandler : IRequestHandler<ChangeSortingDetailsCommand, Response<ChangeSortingDetailsResponse>>
    {
        private readonly IRepository<Sorting> _sortingRepository;
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public ChangeSortingDetailsHandler(IMapper mapper, IRepository<Sorting> sortingRepository, DbContext dbContext)
        {
            _mapper = mapper;
            _sortingRepository = sortingRepository;
            _dbContext = dbContext;
        }

        public async Task<Response<ChangeSortingDetailsResponse>> Handle(ChangeSortingDetailsCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request.Address);

            var sorting = await _dbContext.Set<Sorting>()
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            
            sorting.Address = address;
            sorting.Name = request.Name;
            
            await _sortingRepository.SaveChangesAsync();

            return ResponseFactory.CreateSuccessResponse<ChangeSortingDetailsResponse>();
        }
    }
}