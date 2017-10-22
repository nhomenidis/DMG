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


    public class SettlementMapping
    {
        public SettlementMapping(EntityTypeBuilder<Settlement> entityBuilder)
        {

            //Define Primary Key
            entityBuilder.HasKey(t => t.Id);

            //Define properties in Users DB columns
            entityBuilder.Property(t => t.AllBills)
                         .IsRequired()
                         .HasAnnotation("unique", true);

            entityBuilder.Property(t => t.DownPayment)
                         .IsRequired();

            entityBuilder.Property(t => t.NoOfInstallements)
                         .IsRequired();

            entityBuilder.Property(t => t.Interest)
                         .IsRequired();

            entityBuilder.Property(t => t.InstallmentAmount)
                         .IsRequired();

           

            //Define 1 to many relationship with Bills Table through Foreign Key UserID
            entityBuilder.HasMany(x => x.Bills)
                         .WithOne(w => w.Settlement)
                         .HasForeignKey(y => y.SettlementID)
                         .IsRequired()
                         .OnDelete(DeleteBehavior.Cascade);


        }
    }




}


