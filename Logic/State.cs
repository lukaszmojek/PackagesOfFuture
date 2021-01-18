using Contracts.Responses;
using System.Collections.Generic;
using Contracts.Dtos;


namespace Logic
{
    public static class State
    {
        public static LogInResponse User { get; set; }

        public static string Password { get; set; }

        public static IList<UserDto> Users { get; set; }

        public static IList<PackageDto> UserPackages { get; set; }

        public static IList<PackageDto> AdminPackages { get; set; }

        public static UserDto UserSelectedForDeleting { get; set; }

        public static IList<SupportIssueDto> IssuesForUser { get; set; }

        public static IList<SupportIssueDto> IssuesForSupport { get; set; }

        public static SupportIssueDto SelectedSupportIssue { get; set; }

        public static IList<DroneDto> AdminDrones { get; set; }
        public static IList<SortingDto> AdminSortings { get; set; }
        public static SortingDto LocationSelectedForEditing { get; set; }
        public static DroneDto SelectedDrone { get; set; }
        public static PackageDto SelectedPackage { get; set; }

        public static void DeleteData()
        {
            User = null;
            Password = null;
            Users = new List<UserDto>();
            UserPackages = new List<PackageDto>();
            UserSelectedForDeleting = null;
            IssuesForUser = new List<SupportIssueDto>();
            IssuesForSupport = new List<SupportIssueDto>();
            AdminDrones = new List<DroneDto>();
            AdminSortings = new List<SortingDto>();
        }
 
    }
}
