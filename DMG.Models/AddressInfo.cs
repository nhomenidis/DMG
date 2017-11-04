using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace DMG.Models
{
    public class AddressInfo : EntityBase
    {
        public string Address { get; set; }
        public string County { get; set; }

        public Guid UserId { get; set; }
        public User User { set; get; }
    }
}
