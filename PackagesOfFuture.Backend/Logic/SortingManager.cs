using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contracts.Dtos;

namespace Logic
{
    public static class SortingManager
    {
        public static async Task<bool> Get()
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(AppSettings.Endpoints.GetSortings);

            if (!response.IsSuccessStatusCode) return false;
            
            var sortings = JsonConvert.DeserializeObject<IList<SortingDto>>(
                await response.Content.ReadAsStringAsync()
            );

            State.AdminSortings = sortings;

            return true;
        }

        public static async Task<bool> Register(RegisterSortingDto sortingDto)
        {
            using var http = new HttpClient();

            var json = JsonConvert.SerializeObject(sortingDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.RegisterSorting, data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static async Task<bool> Change(ChangeSortingDetailsDto changeSortingDetailsDto)
        {
            using var http = new HttpClient();

            var json = JsonConvert.SerializeObject(changeSortingDetailsDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.ChangeSortingDetails(changeSortingDetailsDto.Id), data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async static Task<bool> Delete(int id)
        {
            using var http = new HttpClient();

            var response = await http.DeleteAsync(AppSettings.Endpoints.UnregisterDrone(id));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
