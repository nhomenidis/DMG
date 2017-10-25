using System.Collections.Generic;

namespace DMG.Models
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool FirstLogin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Vat { get; set; }

        //navigation properties
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Settlement> Settlements { get; set; }
        public AddressInfo Adress { get; set; }
    }
}
