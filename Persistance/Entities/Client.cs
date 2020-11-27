using System.Collections;

namespace Persistance.Entities
{
    public class Client : Entity
    {
        public string UserName { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Email { get; set; }

        public int AdressId { get; set; }
        public Address Adress { get; set; }
    }
}