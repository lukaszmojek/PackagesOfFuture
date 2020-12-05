using System.Collections;

namespace Persistance.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }

        public int? AdressId { get; set; }
        public virtual Address Adress { get; set; }
    }
}