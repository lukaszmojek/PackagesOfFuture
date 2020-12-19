using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Controllers;
using Api.Factories;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using Api.Responses;

namespace Api.Handlers
{
    public class ChangeUserDetailsHandler : IRequestHandler<ChangeUserDetailsCommand, Response<ChangeUserDetailsResponse>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        
        public ChangeUserDetailsHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ChangeUserDetailsResponse>> Handle(ChangeUserDetailsCommand command, CancellationToken cancellationToken)
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
            catch (Exception)
            {
                return ResponseFactory.CreateFailureResponse<ChangeUserDetailsResponse>(); 
            }
        }
    }
}