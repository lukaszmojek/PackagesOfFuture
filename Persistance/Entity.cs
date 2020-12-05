using System.ComponentModel.DataAnnotations;

namespace Persistance
{
    public abstract class Entity
    {
        [Key]
        public int Id;
    }
}