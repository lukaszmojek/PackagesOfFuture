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

           // var response = await http.PostAsync(AppSettings.Endpoints.Login, data); //
            var response = await http.GetAsync(AppSettings.Endpoints.Register); //
            
            
            if (response.IsSuccessStatusCode)
            {
                //State.User = JsonConvert.DeserializeObject<Response<LogInResponse>>(
                //    await response.Content.ReadAsStringAsync()
                //    ).Content;
                var Users = JsonConvert.DeserializeObject<IList<UserDto>>(
                    await response.Content.ReadAsStringAsync()
                    );
                ;
                
                return true;
            }
           
            return false;
        }

        public static async Task<bool> Register(string firstName, string lastName, string email, int type, string password)
        {
            using var http = new HttpClient();

            var registerDetails = new RegisterUserDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Type = type,
                Password = password
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
    }
}
