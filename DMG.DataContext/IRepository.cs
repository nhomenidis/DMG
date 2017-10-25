using System.Threading.Tasks;

namespace DMG.DatabaseContext
{
    public interface IRepository<T>
    {

        Task<T> GetById(string id);

        Task<T> Insert(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(string id);
    }
}
