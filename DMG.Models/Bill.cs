using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class Bill : EntityBase
    {

        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime DueDate { set; get; }
        public string Status { set; get; }

        public User User { get; set; }
    }
}
