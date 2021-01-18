using Api.Commands;
using Api.Controllers;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;

namespace Api.Profiles
{
    public class SupportIssueProfile : Profile
    {
        public SupportIssueProfile()
        {
            CreateMap<SupportIssue, SupportIssueDto>();
            
            CreateMap<RegisterSupportIssueDto, RegisterSupportIssueCommand>();
            CreateMap<RegisterSupportIssueCommand, SupportIssue>();
            
            CreateMap<ChangeSupportIssueStatusDto, ChangeSupportIssueStatusCommand>();
        }
    }
}