using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShadySoft.EntityPersistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        void Remove(TEntity item);
    }
}