using ResourceEnums;

namespace Contracts.Dtos
{
    public class SupportIssueDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public SupportIssueStatus Status { get; set; }
        public UserDto User { get; set; }
    }
}