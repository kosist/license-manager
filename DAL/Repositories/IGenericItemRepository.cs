using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace DAL.Repositories
{
    public interface IGenericItemRepository<TDomain>
                     where TDomain : BaseItem

    {
        Task<IEnumerable<TDomain>> GetList();
        Task<TDomain> GetById(int? id);
        Task Insert(TDomain item);
        Task Update(TDomain item);
        Task Delete(int? id);
    }
}