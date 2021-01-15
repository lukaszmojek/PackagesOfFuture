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

        public static UserDto UserSelectedForDeleting { get; set; }
    }
}
