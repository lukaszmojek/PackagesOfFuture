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
            public static string ChangeUserDetails(int id) => $"{_host}/users/{id}/changeDetails";
            public static string UnregisterUser(int id) => $"{_host}/users/{id}/unregister";
            public static string GetPackages { get => _host + "/packages"; }
            public static string RegisterPackage { get => _host + "/packages"; }
            public static string GetAdresses { get => _host + "/adresses"; }
            public static string AddAdresses { get => _host + "/adresses"; }
            public static string GetDrones { get => _host + "/drones"; }
            public static string RegisterDrone { get => _host + "/drones"; }
            public static string MoveDroneToSorting(int id) => $"{_host}/drones/{id}/moveToSorting";
            public static string GetVehicles { get => _host + "/vehicles"; }
            public static string RegisterVehicle { get => _host + "/vehicles"; }
            public static string GetServices { get => _host + "/services"; }
            public static string RegisterService { get => _host + "/services"; }
            public static string GetPayments { get => _host + "/payments"; }
            public static string ChangePaymentStatus(int id) => $"{_host}/payments/change-status/{id}";
        }
    }
}