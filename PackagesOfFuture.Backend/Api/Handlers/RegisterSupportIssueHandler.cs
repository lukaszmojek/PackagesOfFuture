using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Controllers;
using Api.Factories;
using AutoMapper;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ResourceEnums;

namespace Api.Handlers
{
    public class RegisterSupportIssueHandler : IRequestHandler<RegisterSupportIssueCommand, Response<RegisterSupportIssueResponse>>
    {
        private IRepository<SupportIssue> _supportIssueRepository;
        private IRepository<User> _userRepository;
        private DbContext _dbContext;
        private IMapper _mapper;

        public RegisterSupportIssueHandler(IMapper mapper, IRepository<SupportIssue> supportIssueRepository, DbContext dbContext, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _supportIssueRepository = supportIssueRepository;
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public async Task<Response<RegisterSupportIssueResponse>> Handle(RegisterSupportIssueCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new ArgumentException(nameof(request.UserId));
            }
            
            var newSupportIssue = _mapper.Map<SupportIssue>(request);
            newSupportIssue.Status = SupportIssueStatus.New;
            newSupportIssue.User = user;

            await _supportIssueRepository.AddAsync(newSupportIssue);
            await _supportIssueRepository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<RegisterSupportIssueResponse>();
        }
    }
}