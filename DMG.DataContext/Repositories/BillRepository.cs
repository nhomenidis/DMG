using DMG.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMG.DatabaseContext.Repositories
{
    public class BillRepository : IRepository<Bill>
    {
       private DbSet<Bill> Bills;

        public BillRepository(DataContext context)
        {
            Bills = context.Set<Bill>();
        }

        public async Task<IEnumerable<Bill>> GetByUserId(string userId)
        {
            var bills = await Bills.Where(x => x.UserId == userId).ToListAsync();

            return bills;
        }

        public async Task<bool> Delete(string id)
        {
            var bill = await Bills.FindAsync(id);

            Bills.Remove(bill);

            return true;
        }

        public async Task<Bill> GetById(string id)
        {
            var bill = await Bills.FindAsync(id);

            return bill;
        }

        public async Task<Bill> Insert(Bill bill)
        {
            var newbill = await Bills.AddAsync(bill);

            return newbill.Entity;
        }

        public bool InsertMany(List<Bill> bills)
        {
            Bills.AddRange(bills);

            return true;
        }
        

        public Bill Update(Bill bill)
        {
            var updatebill = Bills.Update(bill);

            return updatebill.Entity;
        }

        public bool DeleteAll(List<Bill> bills) // Is this the proper way to delete the entire DbSet - Bills?
        {
            foreach (var b in bills)
            {
                Bills.RemoveRange(b);
            }
            return true;
        }

     
    }
}