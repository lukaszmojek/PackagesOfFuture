namespace Contracts.Dtos
{
    public class MoveDroneToSortingDto
    {
        public int DroneId { get; set; }
        public int SortingId { get; set; }
        public string Model { get; set; }
        public int Range { get; set; }
    }
}