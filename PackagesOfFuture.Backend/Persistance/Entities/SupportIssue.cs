using ResourceEnums;

namespace Data.Entities
{
    public class SupportIssue : Entity
    {
        public string Description { get; set; }
        public SupportIssueStatus Status { get; set; }
        
        public virtual User User { get; set; }
    }
}