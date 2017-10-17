using DMG.Models;
using Microsoft.EntityFrameworkCore;


namespace DMG.Data
{
    public class DimosDBContext : DbContext
    {       
        public DimosDBContext(DbContextOptions<DimosDBContext> options) : base(options)
        { }


        public DbSet<User> User { get; set; }
        public DbSet<Bill> Bills { get; set; }
       
        public DbSet<AddressInfo> AddressInfo { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        public DbSet<SettlementBill> SettlementBills { get; set; }
        public DbSet<Settlement> Settlements { get; set; }



    }
}


