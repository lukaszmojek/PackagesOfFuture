using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Factories;

namespace WebApplication.Controllers
{
    public class ChangeUserDetailsHandler : IRequestHandler<ChangeUserDetailsCommand, ChangeUserDetailsResponse>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        
        public ChangeUserDetailsHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ChangeUserDetailsResponse> Handle(ChangeUserDetailsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repository.GetByIdAsync(command.Id)
                           ?? throw new Exception("User does not exist");

                user.UserName = command.UserName;
                user.FirstName = command.FirstName;
                user.LastName = command.LastName;
                user.Email = command.Email;
                user.Type = command.Type;
                user.Password = command.Password;

                await _repository.SaveChangesAsync();

                return ResponseFactory.CreateSuccessResponse<ChangeUserDetailsResponse>();
            }
            catch (Exception e)
            {
                return ResponseFactory.CreateFailureResponse<ChangeUserDetailsResponse>(); 
            }
        }
    }
}