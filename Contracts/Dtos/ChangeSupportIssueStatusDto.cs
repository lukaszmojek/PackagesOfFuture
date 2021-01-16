using ResourceEnums;

namespace Contracts.Dtos
{
    public class ChangeSupportIssueStatusDto
    {
        public int Id { get; set; }
        public SupportIssueStatus Status { get; set; }
    }
}