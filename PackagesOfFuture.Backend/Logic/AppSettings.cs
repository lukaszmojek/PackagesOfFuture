namespace Logic
{
    public static class AppSettings
    {
        public static class Endpoints
        {
            private static string _host = "https://localhost:5001";

            public static string Login { get =>  _host + "/login"; }
            public static string Register { get => _host + "/users"; }
            public static string GetUsers { get => _host + "/users"; }
            public static string ChangeUserDetails(int id) => $"{_host}/users/{id}/change-details";
            public static string ChangeUserPassword(int id) => $"{_host}/users/{id}/change-password";
            public static string UnregisterUser(int id) => $"{_host}/users/{id}/unregister";
            public static string GetPackages { get => _host + "/packages"; }
            public static string GetUserPackages(int id) => $"{_host}/packages/user-packages/{id}";
            public static string RegisterPackage { get => _host + "/packages"; }
            public static string GetAdresses { get => _host + "/adresses"; }
            public static string AddAdresses { get => _host + "/adresses"; }
            public static string GetDrones { get => _host + "/drones"; }
            public static string RegisterDrone { get => _host + "/drones"; }
            public static string MoveDroneToSorting(int id) => $"{_host}/drones/{id}/move-to-sorting";
            public static string UnregisterDrone(int id) => $"{_host}/drones/{id}/unregister";
            public static string GetVehicles { get => _host + "/vehicles"; }
            public static string RegisterVehicle { get => _host + "/vehicles"; }
            public static string GetServices { get => _host + "/services"; }
            public static string RegisterService { get => _host + "/services"; }
            public static string GetPayments { get => _host + "/payments"; }
            public static string ChangePaymentStatus(int id) => $"{_host}/payments/change-status/{id}";
            public static string GetSupportIssues { get => _host + "/support-issues"; }
            public static string GetSupportIssuesForUser (int id) => $"{_host}/support-issues/user-issues/{id}";
            public static string RegisterSupportIssue { get => _host + "/support-issues"; }
            public static string ChangeSupportIssueStatus { get => _host + "/support-issues/change-status"; }
            public static string GetSortings { get => _host + "/sortings"; }
            public static string RegisterSorting { get => _host + "/sortings"; }
            public static string ChangeSortingDetails(int id) => $"{_host}/sortings/{id}/change-details";
        }
    }
}