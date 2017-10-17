using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMG.Models
{
    class User
    {

        public string UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Boolean FirstLogin { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }





        //navihgation properties
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Settlement> Settlements { get; set; }

    }
}
