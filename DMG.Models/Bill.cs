using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class Bill : EntityBase
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { set; get; }
        public string Status { set; get; }

        public User User { get; set; }
    }
}
