using DMG.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMG.DatabaseContext.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> GetById(Guid id);

        Task<IEnumerable<T>> GetAll();

        Task<T> Insert(T entity);

        Task<bool> InsertMany(IEnumerable<T> entities);

        Task<T> Update(T entity);

        Task<bool> Delete(Guid id);
    }
}
