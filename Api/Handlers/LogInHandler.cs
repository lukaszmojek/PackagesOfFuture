using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Factories;
using WebApplication.Queries;
using WebApplication.Responses;

namespace WebApplication.Controllers
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
                .SingleOrDefault(u => u.UserName.Equals(request.Username)
                                      && u.Password.Equals(request.Password));

            if (user.Equals(null))
            {
                return ResponseFactory.CreateFailureResponse<LogInResponse>();
            }

            return ResponseFactory.CreateSuccessResponse<LogInResponse>(_mapper.Map<LogInResponse>(user));
        }
    }
}