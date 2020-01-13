using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShadySoft.EntityPersistence
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync(bool RollbackOnFailure = false)
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (RollbackOnFailure)
                {
                    var changes = _context.ChangeTracker.Entries().Where(ce => ce.State != EntityState.Unchanged);
                    foreach (var ce in changes)
                        await ce.ReloadAsync();
                }
                throw e;
            }
        }
    }
}
