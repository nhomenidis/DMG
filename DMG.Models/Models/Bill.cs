using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMG.Models
{
    public class Bill
    {

        public string BillID { get; set; }

       
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime DueDate { set; get; }
        public string Status { set; get; }

        public User User { get; set; }
        
        
    }
}
