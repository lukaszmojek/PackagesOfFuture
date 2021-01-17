using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Contracts.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using Contracts.Dtos;
using ResourceEnums;

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


        public static async Task<bool> GetUserPackage(int userID)
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(AppSettings.Endpoints.GetUserPackages(userID));

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

        public static async Task<bool> GetAdminPackage()
        {
            using var http = new HttpClient();

            var response = await http.GetAsync(AppSettings.Endpoints.GetPackages);

            if (response.IsSuccessStatusCode)
            {

                var package = JsonConvert.DeserializeObject<IList<PackageDto>>(
                    await response.Content.ReadAsStringAsync()
                    );

                State.AdminPackages = package;

                return true;
            }

            return false;
        }

        public static async Task<bool> PayForPackage(int paymentId)
        {
            using var http = new HttpClient();

            var payment = new ChangePaymentStatusDto()
            {
                PaymentId = paymentId,
                PaymentStatus = PaymentStatus.Completed
            };
            
            var json = JsonConvert.SerializeObject(payment);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await http.PostAsync(AppSettings.Endpoints.ChangePaymentStatus(paymentId), data);

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
