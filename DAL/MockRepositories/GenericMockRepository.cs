using System.Collections.Generic;
using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public abstract class GenericMockRepository<TDomain> : IGenericItemRepository<TDomain> where TDomain : BaseItem
    {
        protected List<TDomain> items;

        public GenericMockRepository()
        {
            items = new List<TDomain>();
        }

        public IEnumerable<TDomain> GetList()
        {
            return items;
        }

        public TDomain GetById(int? id)
        {
            return items.Find(obj => obj.Id == id);
        }

        public void Insert(TDomain item)
        {
            items.Add(item);
        }

        public void Update(TDomain item)
        {
            var oldItem = GetById(item.Id);
            var index = items.IndexOf(oldItem);
            if (index != -1)
                items[index] = item;

        }

        public void Delete(int id)
        {
            items.RemoveAll(obj => obj.Id == id);
        }
    }
}