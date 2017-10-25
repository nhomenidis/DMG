using DMG.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMG.DatabaseContext.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        protected DbSet<T> DbSet { get; set; }
        protected DataContext DataContext { get; set; }

        public BaseRepository(DataContext dataContext)
        {
            DataContext = dataContext;
            DbSet = dataContext.Set<T>();
        }

        public Task<T> GetById(Guid id)
        {
            return DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            var result = DbSet.Add(entity);
            await DataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<T> Update(T entity)
        {
            var result = DbSet.Update(entity);
            await DataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
            await DataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertMany(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
            await DataContext.SaveChangesAsync();
            return true;
        }
    }
}
