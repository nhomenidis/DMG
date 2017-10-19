using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class Payment : EntityBase
    {

        public DateTime DatePerformed { set; get; }
        public float Amount { get; set; }
        public string Method { set; get; }

        public Bill Bill { get; set; }
    }
}
