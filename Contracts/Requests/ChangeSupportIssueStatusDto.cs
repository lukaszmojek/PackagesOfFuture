using Data.Entities;

namespace Api.Controllers
{
    public class ChangeSupportIssueStatusDto
    {
        public int Id { get; set; }
        public SupportIssueStatus Status { get; set; }
    }
}