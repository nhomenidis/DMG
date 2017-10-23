using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMG.Models
{
    public class Bill : EntityBase
    {
        public string BillID { get; set; }   
        public string Description { get; set; }
        public double Amount { get; set; }                      
        public DateTime DueDate { set; get; }
      

        public Payment Payment { set; get; }


        public string UserID { get; set; }
        public User User { get; set; }

        public string SettlementID { get; set; }
        public Settlement Settlement { get; set; }



    }




}
