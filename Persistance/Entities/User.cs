using System.Collections.Generic;
using ResourceEnums;

namespace Data.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public string Password { get; set; }
        
        public virtual Address Address { get; set; }
        public virtual ICollection<SupportIssue> SupportIssues { get; set; }
    }
}