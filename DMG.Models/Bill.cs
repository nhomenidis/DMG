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



    public class BillMapping
    {
        public BillMapping(EntityTypeBuilder<Bill> entityBuilder)
        {

            //Define Primary Key
            entityBuilder.HasKey(t => t.Id);

            //Define properties in Bills DB columns
            entityBuilder.Property(t => t.BillID)
                         .IsRequired()
                         .HasAnnotation("unique", true)
                         .HasMaxLength(250);

            entityBuilder.Property(t => t.Description)
                         .IsRequired()
                         .HasMaxLength(100);

            entityBuilder.Property(t => t.Amount)
                         .IsRequired();

            entityBuilder.Property(t => t.DueDate)
                         .IsRequired();

           

            //Define 1 to 1 relationship with Payments Table through Foreign Key UserID
            entityBuilder.HasOne(x => x.Payment)
                         .WithOne(b => b.Bill)
                         .HasForeignKey<Payment>(b => b.BillID)
                         .IsRequired()
                         .OnDelete(DeleteBehavior.Cascade);      



        }
    }


}
