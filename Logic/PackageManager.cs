using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Contracts.Requests;
using Contracts.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logic
{
    public static class PackageManager
    {
        public static async Task<bool> AddPackage(AddressDto deliveryAddress, AddressDto pickUpAddress, PackageDetailsDto package, int serviceID, CreatePaymentDto payment)
        {
            using var http = new HttpClient();

            var packageDetails = new RegisterPackageDto()
            {
                DeliveryAddress = deliveryAddress,
                ReceiveAddress = pickUpAddress,
                Package = package,
                ServiceId = serviceID,
                Payment = payment
            };

            var json = JsonConvert.SerializeObject(packageDetails);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(AppSettings.Endpoints.RegisterPackage, data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public static async Task<bool> GetPackage()
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(AppSettings.Endpoints.GetPackages);

            if (response.IsSuccessStatusCode)
            {

                var package = JsonConvert.DeserializeObject<IList<PackageDto>>(
                    await response.Content.ReadAsStringAsync()
                    );

                State.UserPackages = package;

                return true;
            }

            return false;
        }


    }
}
