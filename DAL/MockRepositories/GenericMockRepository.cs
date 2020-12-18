using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<TDomain>> GetList()
        {
            return await Task.FromResult(items);
        }

        public async Task<TDomain> GetById(int? id)
        {
            return await Task.FromResult(items.Find(obj => obj.Id == id));
        }

        public async Task Insert(TDomain item)
        {
            if (item.Id == null)
            {
                item.Id = 0;
                if (items.Count != 0)
                {
                    var newId = items[items.Count-1].Id + 1;
                    item.Id = newId;
                }
            }
            items.Add(item);
        }

        public async Task Update(TDomain item)
        {
            var oldItem = GetById(item.Id);
            var index = items.IndexOf(oldItem);
            if (index != -1)
                items[index] = item;

        }

        public async Task Delete(int? id)
        {
            items.RemoveAll(obj => obj.Id == id);
        }
    }
}