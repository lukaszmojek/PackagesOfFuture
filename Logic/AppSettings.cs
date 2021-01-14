namespace Logic
{
    public static class AppSettings
    {
        public static class Endpoints
        {
            private static string _host = "https://localhost:5001";

            public static string Login { get =>  _host + "/login"; }

            public static string Register { get => _host + "/users";  }


            //public static string Register { get => _host + "/users"; }
        }
    }
}