using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class AddressInfo : EntityBase
    {
        public string Address { get; set; }
        public string County { get; set; }

        public string UserID { set; get; }
        public User User { set; get; }
    }
}
