using Data.Entities;

namespace Api.Controllers
{
    public class SupportIssueDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public SupportIssueStatus Status { get; set; }
    }
}