namespace Data.Entities
{
    public class Drone : Entity
    {
        public string Model { get; set; }
        public int Range { get; set; }
        
        public virtual Sorting Sorting { get; set; }
    }
}