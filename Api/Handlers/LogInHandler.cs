using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.Responses;
using Api.Factories;
using Api.Queries;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;

namespace Api.Handlers
{
    public class LogInHandler : IRequestHandler<LogInQuery, Response<LogInResponse>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public LogInHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<LogInResponse>> Handle(LogInQuery request, CancellationToken cancellationToken)
        {
            var user = (await _repository.GetAsync())
                .SingleOrDefault(u => u.UserName.Equals(request.Email)
                                      && u.Password.Equals(request.Password));

            if (user == null)
            {
                return ResponseFactory.CreateFailureResponse<LogInResponse>();
            }

            return ResponseFactory.CreateSuccessResponse<LogInResponse>(_mapper.Map<LogInResponse>(user));
        }
    }
}