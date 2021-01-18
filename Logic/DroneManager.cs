using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contracts.Dtos;

namespace Logic
{
    public static class DroneManager
    {
        public static async Task<bool> GetDrones()
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(AppSettings.Endpoints.GetDrones);

            if (response.IsSuccessStatusCode)
            {

                var drones = JsonConvert.DeserializeObject<IList<DroneDto>>(
                    await response.Content.ReadAsStringAsync()
                    );

                State.AdminDrones = drones;

                return true;
            }

            return false;
        }

        public static async Task<bool> AddDrone(string model, int range, int sortingId)
        {
            using var http = new HttpClient();

            var dronDetails = new RegisterDroneDto()
            {
                Model = model,
                Range = range,
                SortingId = sortingId
            };

            var json = JsonConvert.SerializeObject(dronDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.RegisterDrone, data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static async Task<bool> DeleteDrone(int droneID)
        {
            using var http = new HttpClient();

            var response = await http.DeleteAsync(AppSettings.Endpoints.UnregisterDrone(droneID));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public static async Task<bool> ChangeDroneLocation(int droneID, int locationID)
        {
            using var http = new HttpClient();

            var changeDetails = new MoveDroneToSortingDto()
            {
                DroneId = droneID,
                SortingId = locationID
            };

            var json = JsonConvert.SerializeObject(changeDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.MoveDroneToSorting(droneID), data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
