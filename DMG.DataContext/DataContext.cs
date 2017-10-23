using Microsoft.EntityFrameworkCore;
using DMG.Models;

namespace DMG.DatabaseContext
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var userBuilder = modelBuilder.Entity<User>();


                    //Define Primary Key
                    userBuilder.HasKey(t => t.Id);

                    //Define properties in Users DB columns
                    userBuilder.Property(t => t.Vat)
                                     .IsRequired()
                                     .HasAnnotation("unique", true)
                                     .HasMaxLength(50);

                    userBuilder.Property(t => t.FirstName)
                                     .IsRequired()
                                     .HasMaxLength(50);

                    userBuilder.Property(t => t.LastName)
                                     .IsRequired()
                                     .HasMaxLength(50);

                    userBuilder.Property(t => t.Password)
                                     .IsRequired();

                    userBuilder.Property(t => t.Email)
                                     .IsRequired()
                                     .HasAnnotation("unique", true);

                    userBuilder.Property(t => t.Phone)
                                    .IsRequired()
                                    .HasMaxLength(50);

                    //Define 1 to 1 relationship with AddressInfo Table through Foreign Key UserID
                    userBuilder.HasOne(x => x.AddressInfo)
                                     .WithOne(b => b.User)
                                     .HasForeignKey<AddressInfo>(b => b.UserID)
                                     .IsRequired()
                                     .OnDelete(DeleteBehavior.Cascade);

                    //Define 1 to many relationship with Bills Table through Foreign Key UserID
                    userBuilder.HasMany(x => x.Bills)
                                     .WithOne(w => w.User)
                                     .HasForeignKey(y => y.UserID)
                                     .IsRequired()
                                     .OnDelete(DeleteBehavior.Cascade);

            //Define 1 to many relationship with Settlements through Foreigh Key UserID *** Optional Relationship ****
                  userBuilder.HasMany(x => x.Settlements)
                                  .WithOne(w => w.User)
                                  .HasForeignKey(h => h.UserID)
                                  .OnDelete(DeleteBehavior.Cascade);         //WILL CHECK




            var AddressBuilder = modelBuilder.Entity<AddressInfo>();

                            //Define Primary Key
                            AddressBuilder.HasKey(t => t.Id);

                            //Define properties in AddressInfo DB columns
                            AddressBuilder.Property(t => t.Address)
                                         .IsRequired()
                                         .HasMaxLength(250);

                            AddressBuilder.Property(t => t.County)
                                         .IsRequired()
                                         .HasMaxLength(100);


            var BillBuilder = modelBuilder.Entity<Bill>();

                    //Define Primary Key
                    BillBuilder.HasKey(t => t.Id);

                    //Define properties in Bills DB columns
                    BillBuilder.Property(t => t.BillID)
                                 .IsRequired()
                                 .HasAnnotation("unique", true)
                                 .HasMaxLength(250);

                    BillBuilder.Property(t => t.Description)
                                 .IsRequired()
                                 .HasMaxLength(100);

                    BillBuilder.Property(t => t.Amount)
                                 .IsRequired();

                    BillBuilder.Property(t => t.DueDate)
                                 .IsRequired();



                    //Define 1 to 1 relationship with Payments Table through Foreign Key UserID
                    BillBuilder.HasOne(x => x.Payment)
                                 .WithOne(b => b.Bill)
                                 .HasForeignKey<Payment>(b => b.BillID)
                                 .IsRequired()
                                 .OnDelete(DeleteBehavior.Cascade);



            var PaymentBuilder = modelBuilder.Entity<Payment>();



                    //Define Primary Key
                    PaymentBuilder.HasKey(t => t.Id);


                    //Define properties in Payment DB columns
                    PaymentBuilder.Property(t => t.Method)
                                 .IsRequired()
                                 .HasMaxLength(50);

                    PaymentBuilder.Property(t => t.Amount)
                                 .IsRequired();

                    PaymentBuilder.Property(t => t.DatePerformed)
                                 .IsRequired();

            var SettlementBuilder = modelBuilder.Entity<Settlement>();


            //Define Primary Key
            SettlementBuilder.HasKey(t => t.Id);

            //Define properties in Users DB columns
            SettlementBuilder.Property(t => t.AllBills)
                         .IsRequired()
                         .HasAnnotation("unique", true);

            SettlementBuilder.Property(t => t.DownPayment)
                         .IsRequired();

            SettlementBuilder.Property(t => t.NoOfInstallements)
                         .IsRequired();

            SettlementBuilder.Property(t => t.Interest)
                         .IsRequired();

            SettlementBuilder.Property(t => t.InstallmentAmount)
                         .IsRequired();



            //Define 1 to many relationship with Bills Table through Foreign Key UserID
            SettlementBuilder.HasMany(x => x.Bills)
                         .WithOne(w => w.Settlement)
                         .HasForeignKey(y => y.SettlementID)
                         .IsRequired()
                         .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
