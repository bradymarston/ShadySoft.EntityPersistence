using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShadySoft.EntityPersistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        void Remove(TEntity item);

        async Task<TEntity> GetSingleOrDefaultAsync(Func<TEntity, bool> filterPredicate)
        {
            return (await GetAsync()).SingleOrDefault(filterPredicate);
        }
        async Task<IEnumerable<TEntity>> GetWhereAsync(Func<TEntity, bool> filterPredicate)
        {
            return (await GetAsync()).Where(filterPredicate).ToList();
        }
    }
}