using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DAL.EFRepositories
{
    public abstract class GenericEfCoreRepository<TDomain, TContext> : IEfCoreRepository<TDomain, TContext>
        where TDomain : BaseItem
        where TContext : DbContext
    {
        private readonly TContext _context;

        public GenericEfCoreRepository(TContext context)
        {
            _context = context;
        }

        public async Task Delete(int? id)
        {
            var entity = await _context.Set<TDomain>().FindAsync(id);
            if (entity == null)
            _context.Set<TDomain>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TDomain> GetById(int? id)
        {
            return await _context.Set<TDomain>().FindAsync(id);
        }

        public async Task<IEnumerable<TDomain>> GetList()
        {
            return await _context.Set<TDomain>().ToListAsync();
        }

        public async Task Insert(TDomain item)
        {
            _context.Set<TDomain>().Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TDomain item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
