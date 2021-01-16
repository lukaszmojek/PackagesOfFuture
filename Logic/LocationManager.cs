using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class LocationManager
    {
        //public static async Task<bool> RegisterLocation()
        //{
        //    using var http = new HttpClient();

        //    var locationDetails = new RegisterLocationDto()
        //    {

        //    };

        //    var json = JsonConvert.SerializeObject(locationDetails);
        //    var data = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = await http.PostAsync(AppSettings.Endpoints.RegisterLocation, data);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public static async Task<bool> GetLocations()
        //{
        //    using var http = new HttpClient();

        //    var response = await http.GetAsync(AppSettings.Endpoints.GetLocations);

        //    if (response.IsSuccessStatusCode)
        //    {

        //        var locations = JsonConvert.DeserializeObject<IList<LocationsDto>>(
        //            await response.Content.ReadAsStringAsync()
        //            );

        //        State.Locations = locations;

        //        return true;
        //    }

        //    return false;
        //}


        //public static async Task<bool> DeleteLocation(int locationID)
        //{
        //    using var http = new HttpClient();

        //    var response = await http.DeleteAsync(AppSettings.Endpoints.UnregisterLocation(locationID));

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
