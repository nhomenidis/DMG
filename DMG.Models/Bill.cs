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
        public bool IsPayed { set; get; }

        public Guid UserId { get; set; } // foreign key
        public User User { get; set; } //navigation property
    }
}
