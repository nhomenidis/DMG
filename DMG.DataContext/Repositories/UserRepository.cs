using DMG.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMG.DatabaseContext.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByVat(string vat);
    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(DataContext context) : base(context) //call parent constructor
        {
        }

        public async Task<User> GetByVat(string vat)
        {
            var result = await DbSet.FirstOrDefaultAsync(user => user.Vat == vat);

            return result;
        }
    }
}