using DMG.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMG.DatabaseContext
{
    public class UserRepository : IRepository<User>
    {
        private DbSet<User> dbSet;

        public UserRepository(DataContext context)
        {
            dbSet = context.Set<User>();
        }

        public async Task<User> GetByUsername(string username)
        {
            var entity = await dbSet.FirstOrDefaultAsync(x => x.Vat == username);

            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await dbSet.FindAsync(id);

            dbSet.Remove(entity);

            return true;
        }

        public async Task<User> GetById(string id)
        {
            var entity = await dbSet.FindAsync(id);

            return entity;
        }

        public async Task<User> Insert(User entity)
        {
            var user = await dbSet.AddAsync(entity);

            return user.Entity;
        }

        public bool InsertMany(List<User> entities)
        {
            dbSet.AddRange(entities);

            return true;
        }
        

        public User Update(User entity)
        {
            var user = dbSet.Update(entity);

            return user.Entity;
        }

     
    }
}