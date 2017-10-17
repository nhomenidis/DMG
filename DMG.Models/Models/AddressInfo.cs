using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations.Schema;

namespace DMG.Models
{
    public class AddressInfo
    {
        public int ID { set; get; }
        public string Address { get; set; }
        public string County { get; set; }

        public User User { set; get; }

    }
}
