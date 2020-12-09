using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Contracts;
using WebApplication.Controllers;
using WebApplication.Queries;
using WebApplication.Responses;

namespace WebApplication.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, ICollection<UserDto>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        
        public GetUsersHandler( IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<ICollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAsync()
                .ConfigureAwait(false);

            return _mapper.Map<ICollection<UserDto>>(users);
        }
    }
}