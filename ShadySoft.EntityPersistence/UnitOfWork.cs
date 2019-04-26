using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
