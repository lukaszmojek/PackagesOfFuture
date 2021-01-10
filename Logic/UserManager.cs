using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Contracts.Requests;
using Contracts.Responses;
using Newtonsoft.Json;


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
                State.User = JsonConvert.DeserializeObject<Response<LogInResponse>>(
                    await response.Content.ReadAsStringAsync()
                    ).Content;

                return true;
            }
           
            return false;
        }
    }
}
