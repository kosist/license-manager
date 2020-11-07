using System.Collections.Generic;
using Domain;

namespace DAL.Repositories
{
    public interface IGenericItemRepository<TDomain>
                     where TDomain : BaseItem

    {
        IEnumerable<TDomain> GetList();
        TDomain GetById(int id);
        void Insert(TDomain item);
        void Update(TDomain item);
        void Delete(int id);
    }
}