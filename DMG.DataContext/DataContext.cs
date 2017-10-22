using Microsoft.EntityFrameworkCore;
using DMG.Models;

namespace DMG.DatabaseContext
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<AddressInfo>  AdressInfo { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments  { get; set; }
        public DbSet<Settlement> Settlements  { get; set; }
        public DbSet<SettlementType> SettlementTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("dbo"); //will check later


        }

       

    }
}
