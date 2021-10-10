namespace Data.Entities
{
    public class Vehicle : Entity
    {
        public string Model { get; set; }
        
        public virtual Sorting Sorting { get; set; }
    }
}