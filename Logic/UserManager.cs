using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Contracts.Requests;
using Contracts.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logic
{
    public static class UserManager
    {
        public static async Task<bool> LogIn(string username, string password)
        {
            using var http = new HttpClient();

            var loginDetails = new LogInDto()
            {
                Email = username, 
                Password = password
            };

            var json = JsonConvert.SerializeObject(loginDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.Login, data); 
            
            if (response.IsSuccessStatusCode)
            {
                State.Password = password;
                State.User = JsonConvert.DeserializeObject<Response<LogInResponse>>(
                    await response.Content.ReadAsStringAsync()
                   ).Content;  
                return true;
            }
            return false;
        }

        public static async Task<bool> Register(string firstName, string lastName, string email, int type, string password, CreateAddressDto address)
        {
            using var http = new HttpClient();

            var registerDetails = new RegisterUserDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Type = type,
                Password = password,
                Address = address
            };

            var json = JsonConvert.SerializeObject(registerDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.Register, data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public static async Task<bool> ChangePassword(int userID, string newPassword)
        {
            using var http = new HttpClient();

            var userDetails = new ChangeUserPasswordDto()
            {
                UserId = userID,
                NewPassword = newPassword
            };

            var json = JsonConvert.SerializeObject(userDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.ChangeUserPassword(userID), data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static async Task<bool> GetUsers()
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(AppSettings.Endpoints.GetUsers);


            if (response.IsSuccessStatusCode)
            {
                var users = JsonConvert.DeserializeObject<IList<UserDto>>(
                    await response.Content.ReadAsStringAsync()
                    );

                

                return true;
            }

            return false;
        }










    }
}
