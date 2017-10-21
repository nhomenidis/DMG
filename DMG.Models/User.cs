using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class User : EntityBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Boolean FirstLogin { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Vat { get; set; }

        //navihgation properties
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Settlement> Settlements { get; set; }

        public User()
        {
            Bills = new HashSet<Bill>();
            Settlements = new HashSet<Settlement>();
        }
    }
}
