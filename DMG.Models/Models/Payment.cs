using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMG.Models
{
    public class Payment
    {   
        public int PaymentID { get; set; }
      
        
        public DateTime DatePerformed { set; get; }
        public float Amount { get; set; }
        public string Method { set; get; }
   
        public Bill Bill { get; set; }
       

         }
}
