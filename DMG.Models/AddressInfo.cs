using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class AddressInfo : EntityBase
    {
        public string Address { get; set; }
        public string County { get; set; }

        public string UserID { set; get; }
        public User User { set; get; }
    }


    public class AddressMapping
    {
        public AddressMapping(EntityTypeBuilder<AddressInfo> entityBuilder)
        {

            //Define Primary Key
            entityBuilder.HasKey(t => t.Id);

            //Define properties in AddressInfo DB columns
            entityBuilder.Property(t => t.Address)
                         .IsRequired()
                         .HasMaxLength(250);

            entityBuilder.Property(t => t.County)
                         .IsRequired()
                         .HasMaxLength(100);

            
        }
    }





}
