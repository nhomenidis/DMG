using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DMG.Models
{
    public class User : EntityBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Vat { get; set; }
        public string Password { get; set; }
        
        public AddressInfo AddressInfo { set; get;}

        public ICollection<Bill> Bills { get; set; }
        public ICollection<Settlement> Settlements { get; set; }

        public User()
        {
            Bills = new HashSet<Bill>();
            Settlements = new HashSet<Settlement>();
        }
    }



    public class UserMapping
    {
        public UserMapping(EntityTypeBuilder<User> entityBuilder)
        {

            //Define Primary Key
            entityBuilder.HasKey(t => t.Id);

            //Define properties in Users DB columns
            entityBuilder.Property(t => t.Vat)
                         .IsRequired()
                         .HasAnnotation("unique", true)
                         .HasMaxLength(50);

            entityBuilder.Property(t => t.FirstName)
                         .IsRequired()
                         .HasMaxLength(50);

            entityBuilder.Property(t => t.LastName)
                         .IsRequired()
                         .HasMaxLength(50); 

            entityBuilder.Property(t => t.Password)
                         .IsRequired();

            entityBuilder.Property(t => t.Email)
                         .IsRequired()
                         .HasAnnotation("unique", true);

            entityBuilder.Property(t => t.Phone)
                        .IsRequired()
                        .HasMaxLength(50);

            //Define 1 to 1 relationship with AddressInfo Table through Foreign Key UserID
            entityBuilder.HasOne(x => x.AddressInfo)
                         .WithOne(b => b.User)
                         .HasForeignKey<AddressInfo>(b => b.UserID)
                         .IsRequired()
                         .OnDelete(DeleteBehavior.Cascade);

            //Define 1 to many relationship with Bills Table through Foreign Key UserID
            entityBuilder.HasMany(x => x.Bills)
                         .WithOne(w => w.User)
                         .HasForeignKey(y =>y.UserID)
                         .IsRequired()
                         .OnDelete(DeleteBehavior.Cascade); 

            //Define 1 to many relationship with Settlements through Foreigh Key UserID *** Optional Relationship ****
            entityBuilder.HasMany(x => x.Settlements)
                         .WithOne(w => w.User)
                         .HasForeignKey(h => h.UserID)
                         .OnDelete(DeleteBehavior.Cascade);         //WILL CHECK


            
        }
    }


}
