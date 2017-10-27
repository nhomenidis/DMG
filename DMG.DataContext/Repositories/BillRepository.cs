using DMG.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMG.DatabaseContext.Repositories
{
    public interface IBillRepository : IRepository<Bill>
    {
        Task<bool> DeleteAll();
        Task<IEnumerable<Bill>> GetByUserId(Guid userId);
        Task<IEnumerable<Bill>> GetByUserVat(string Vat);
    }

    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {

        public BillRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Bill>> GetByUserId(Guid userId)
        {
            var bills = await DbSet
                .Where(bill => bill.UserId == userId)
                .ToListAsync();

            return bills;
        }

        public async Task<IEnumerable<Bill>> GetByUserVat(string Vat)
        {
            var bills = await DbSet
                .Where(bill => bill.User.Vat == Vat)
                .ToListAsync();

            return bills;
        }

        public async Task<bool> DeleteAll()
        {
            foreach (var bill in DbSet)
            {
                DbSet.Remove(bill);
            }
            await DataContext.SaveChangesAsync();
            return true;
        }
    }
}