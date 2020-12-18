using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DAL.EFRepositories
{
    public interface IEfCoreRepository<TDomain, TContext> : IGenericItemRepository<TDomain>
        where TDomain   : BaseItem
        where TContext  : DbContext
    {

    }
}
