using Contracts.Requests;
using Contracts.Responses;
using System.Collections.Generic;


namespace Logic
{
    public static class State
    {
        public static LogInResponse User { get; set; }

        public static string Password { get; set; }

        public static IList<UserDto> Users { get; set; }

        public static IList<PackageDto> UserPackages { get; set; }

        public static UserDto UserSelectedForDeleting { get; set; }

        public static IList<SupportIssueDto> IssuesForUser { get; set; }

        public static IList<SupportIssueDto> IssuesForSupport { get; set; }

        public static SupportIssueDto SelectedSupportIssue { get; set; }

        public static IList<DroneDto> AdminDrones { get; set; }

        public static void DeleteData()
        {
            User = null;
            Password = null;
            Users = null;
            UserPackages = null;
            UserSelectedForDeleting = null;
            IssuesForUser = null;
            IssuesForSupport = null;
        }
 
    }
}
