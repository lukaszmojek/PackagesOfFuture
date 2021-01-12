namespace Logic
{
    public static class AppSettings
    {
        public static class Endpoints
        {
            private static string _host = "http://localhost:59444";

            public static string Login { get =>  _host + "/login"; }
        }
    }
}