using ResourceEnums;

namespace Contracts.Requests
{
    public class ChangeSupportIssueStatusDto
    {
        public int Id { get; set; }
        public SupportIssueStatus Status { get; set; }
    }
}