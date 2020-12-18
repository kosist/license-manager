using System.Collections.Generic;
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

        public void Delete(int? id)
        {
            var entity = _context.Set<TDomain>().Find(id);
            if (entity == null)
            _context.Set<TDomain>().Remove(entity);
            _context.SaveChanges();
        }

        public TDomain GetById(int? id)
        {
            return _context.Set<TDomain>().Find(id);
        }

        public IEnumerable<TDomain> GetList()
        {
            return _context.Set<TDomain>().ToListAsync().Result;
        }

        public void Insert(TDomain item)
        {
            _context.Set<TDomain>().Add(item);
            _context.SaveChanges();
        }

        public void Update(TDomain item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
