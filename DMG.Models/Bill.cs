using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;


namespace DMG.Models
{
    public class Bill : EntityBase //(no need for an extra Id because the bill comes ready with it's own Guid Bill Id
    {
        public Guid BillId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateDue { set; get; }
        public DateTime DatePayed { get; set; }
        public bool IsPayed { set; get; }

        public Guid UserId { get; set; } // foreign key
        public User User { get; set; } //navigation property
        public string UserVat { get; set; }
    }
}
