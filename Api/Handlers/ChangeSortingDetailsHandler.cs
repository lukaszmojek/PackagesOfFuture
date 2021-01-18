using System.Threading;
using System.Threading.Tasks;
using Api.Factories;
using AutoMapper;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    public class ChangeSortingDetailsHandler : IRequestHandler<ChangeSortingDetailsCommand, Response<ChangeSortingDetailsResponse>>
    {
        private IRepository<Sorting> _sortingRepository;
        private IRepository<Address> _addressRepository;
        private DbContext _dbContext;
        private IMapper _mapper;

        public ChangeSortingDetailsHandler(IMapper mapper, IRepository<Address> addressRepository, IRepository<Sorting> sortingRepository, DbContext dbContext)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _sortingRepository = sortingRepository;
            _dbContext = dbContext;
        }

        public async Task<Response<ChangeSortingDetailsResponse>> Handle(ChangeSortingDetailsCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request.Address);

            var sorting = await _dbContext.Set<Sorting>()
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            
            sorting.Address = address;
            sorting.Name = request.Name;
            
            await _sortingRepository.SaveChangesAsync();

            return ResponseFactory.CreateSuccessResponse<ChangeSortingDetailsResponse>();
        }
    }
}