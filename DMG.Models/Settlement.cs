using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
   public class Settlement : EntityBase
    {
      
        public string AllBills { set; get; }
        public double DownPayment { set; get; }
        public int NoOfInstallements { set; get; }
        public double Interest { set; get; }
        public double InstallmentAmount { set; get; }
        
        public string UserID { set; get; }
        public User User { get; set; }

        public ICollection<Bill> Bills { get; set; }

        public Settlement()
        {
            Bills = new HashSet<Bill>();
        }
    }






}


