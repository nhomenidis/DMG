using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class Payment : EntityBase
    {

        public DateTime DatePerformed { set; get; }
        public double Amount { get; set; }
        public string Method { set; get; }

        public string BillID { get; set; }
        public Bill Bill { get; set; }
    }



    public class PaymentMapping
    {
        public PaymentMapping(EntityTypeBuilder<Payment> entityBuilder)
        {

            //Define Primary Key
            entityBuilder.HasKey(t => t.Id);


            //Define properties in Payment DB columns
            entityBuilder.Property(t => t.Method)
                         .IsRequired()
                         .HasMaxLength(50);

            entityBuilder.Property(t => t.Amount)
                         .IsRequired();

            entityBuilder.Property(t => t.DatePerformed)
                         .IsRequired();

            
        }
    }
}
