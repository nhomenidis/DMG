using DMG.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMG.DatabaseContext.Repositories
{
    public class UserRepository : IRepository<User>
    {
       private DbSet<User> Users;

        public UserRepository(DataContext context)
        {
            Users = context.Set<User>();
        }

        public async Task<User> GetByUsername(string username)
        {
            var user = await Users.FirstOrDefaultAsync(x => x.FirstName+" "+ x.LastName == username);

            return user;
        }

        public async Task<bool> Delete(string id)
        {
            var user = await Users.FindAsync(id);

            Users.Remove(user);

            return true;
        }

        public async Task<User> GetById(string id)
        {
            var user = await Users.FindAsync(id);

            return user;
        }

        public async Task<User> Insert(User entity)
        {
            var user = await Users.AddAsync(entity);

            return user.Entity;
        }

        public bool  InsertMany(List<User> users) // can't we make this asynchronously?
        {
           Users.AddRange(users);

           return true;
        }
        

        public User Update(User entity)
        {
            var user = Users.Update(entity);

            return user.Entity;
        }

     
    }
}