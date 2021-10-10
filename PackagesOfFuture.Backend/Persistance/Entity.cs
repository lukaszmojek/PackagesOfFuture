using System.ComponentModel.DataAnnotations;

namespace Data
{
    public abstract class Entity
    {
        [Key]
        public int Id;
    }
}