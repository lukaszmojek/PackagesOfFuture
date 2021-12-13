using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contracts.Dtos;
using Contracts.Responses;
using Newtonsoft.Json;

namespace Console.ApiSandbox
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var http = new HttpClient();
            
            var loginDetails = new AuthenticateUserDto() {Email = "hjanek", Password = "debil123"};
            
            var json = JsonConvert.SerializeObject(loginDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync("https://localhost:5001/login", data);

            if (response.IsSuccessStatusCode)
            {
                var user = JsonConvert.DeserializeObject<Response<AuthenticateUserResponse>>(await response.Content.ReadAsStringAsync()).Content;
                System.Console.WriteLine("Oł je, zalogowany dzban");
            }
            else
            {
                System.Console.WriteLine("Cos nie pyklo");
            }
        }
    }
}