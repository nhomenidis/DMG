using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean FirstLogin { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Vat { get; set; }

        //navigation properties
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Settlement> Settlements { get; set; }
        public AddressInfo Adress { get; set; }

        public User()
        {
            Bills = new HashSet<Bill>();
            Settlements = new HashSet<Settlement>();
        }
    }
}
