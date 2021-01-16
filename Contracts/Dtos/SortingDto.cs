using System.Collections.Generic;

namespace Contracts.Dtos
{
    public class SortingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<PackageDto> Packages { get; set; }
        public ICollection<DroneDto> Drones { get; set; }
        public ICollection<VehicleDto> Vehicles { get; set; }
    }
}