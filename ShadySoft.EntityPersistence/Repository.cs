using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadySoft.EntityPersistence
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        virtual public void Add(TEntity item)
        {
            _context.Add(item);
        }

        virtual public async Task<TEntity> GetAsync(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        virtual public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        virtual public void Remove(TEntity item)
        {
            _context.Remove(item);
        }
        virtual public async Task<TEntity> GetSingleOrDefaultAsync(Func<TEntity, bool> filterPredicate)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(e => filterPredicate(e));
        }
        virtual public async Task<IEnumerable<TEntity>> GetWhereAsync(Func<TEntity, bool> filterPredicate)
        {
            return await _context.Set<TEntity>().Where(e => filterPredicate(e)).ToListAsync();
        }
    }
}
