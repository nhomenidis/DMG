﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DMG.Models
{
    public class User : EntityBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Vat { get; set; }
        public string Password { get; set; }

        public AddressInfo AddressInfo { set; get; }

        public ICollection<Bill> Bills { get; set; }
        public ICollection<Settlement> Settlements { get; set; }

        public User()
        {
            Bills = new HashSet<Bill>();
            Settlements = new HashSet<Settlement>();
        }
    }

}
