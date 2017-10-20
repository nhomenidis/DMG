using DMG.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMG.DatabaseContext.Repositories
{
    public class BillRepository : IRepository<Bill>
    {
        private DbSet<Bill> dbSet;

        public BillRepository(DataContext context)
        {
            dbSet = context.Set<Bill>();
        }

        // Get a bill list by a specific User
        public async Task<ICollection<Bill>> GetByUser (User user)
        {
            var  entity = await dbSet.FindAsync(user);

            return entity.User.Bills;
        }

        // Remove a bill
        public async Task<bool> Delete(string id)
        {
            var entity = await dbSet.FindAsync(id);

            dbSet.Remove(entity);

            return true;
        }

        // Get bill by Id
        public async Task<Bill> GetById(string id)
        {
            var entity = await dbSet.FindAsync(id);

            return entity;
        }

        // Insert a bill
        public async Task<Bill> Insert(Bill entity)
        {
            var user = await dbSet.AddAsync(entity);

            return user.Entity;
        }

        // Add many bills
        public bool InsertMany(List<Bill> entities)
        {
            dbSet.AddRange(entities);

            return true;
        }
        
        // Update a bill
        public Bill Update(Bill entity)
        {
            var user = dbSet.Update(entity);

            return user.Entity;
        }

     
    }
}