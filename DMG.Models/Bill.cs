using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class Bill : EntityBase
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { set; get; }
        public Boolean IsPayed { set; get; }
        public string UserId { get; set; } // foreign key

        //navigation property
        public User User { get; set; }
    }
}
