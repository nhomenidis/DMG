using System.Security.Cryptography.X509Certificates;
using DMG.Models;
using Microsoft.EntityFrameworkCore;

namespace DMG.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<AddressInfo> AddressInfos { get; set; }
        
        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}
