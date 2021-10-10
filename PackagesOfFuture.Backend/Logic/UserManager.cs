using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Contracts.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Contracts.Dtos;
using Data.Entities;
using ResourceEnums;

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
            var error = await response.Content.ReadAsStringAsync();
               

            //var error = JsonConvert.DeserializeObject<string>(
            //await response.Content.ReadAsStringAsync()
       // );
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

                State.Users = users;

                return true;
            }

            return false;
        }

        public static async Task<bool> ChangeUserDetails(string firstname, string lastname, AddressDto address)
        {
            using var http = new HttpClient();

            var userDetails = new ChangeUserDetailsDto()
            {
                Id = State.User.Id,
                FirstName = firstname,
                LastName = lastname,
                Address = address
            };

            var json = JsonConvert.SerializeObject(userDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.ChangeUserDetails(State.User.Id), data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static async Task<bool> DeleteUser(int userId)
        {
            using var http = new HttpClient();

            var response = await http.DeleteAsync(AppSettings.Endpoints.UnregisterUser(userId));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public static async Task<bool> NewIssue(int userID, string description)
        {
            using var http = new HttpClient();

            var issueDetails = new RegisterSupportIssueDto()
            {
                UserId = userID,
                Description = description
            };

            var json = JsonConvert.SerializeObject(issueDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.RegisterSupportIssue, data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> GetIssuesForUser(int userID)
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(AppSettings.Endpoints.GetSupportIssuesForUser(userID));

            if (response.IsSuccessStatusCode)
            {
                var issues = JsonConvert.DeserializeObject<IList<SupportIssueDto>>(
                    await response.Content.ReadAsStringAsync()
                    );

                State.IssuesForUser = issues;

                return true;
            }

            return false;
        }

        public static async Task<bool> GetIssuesForSupport()
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(AppSettings.Endpoints.GetSupportIssues);

            if (response.IsSuccessStatusCode)
            {
                var issues = JsonConvert.DeserializeObject<IList<SupportIssueDto>>(
                    await response.Content.ReadAsStringAsync()
                    );

                State.IssuesForSupport = issues;

                return true;
            }

            return false;
        }

        public static async Task<bool> ChangeSupportIssueStatus(int id, SupportIssueStatus status)
        {
            using var http = new HttpClient();

            var issueDetails = new ChangeSupportIssueStatusDto()
            {
                Id = id,
                Status = status
            };

            var json = JsonConvert.SerializeObject(issueDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.ChangeSupportIssueStatus, data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
