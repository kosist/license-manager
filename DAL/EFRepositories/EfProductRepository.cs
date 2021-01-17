using DAL.Repositories;
using Domain;

namespace DAL.EFRepositories
{
    public class EfProductRepository : GenericEfCoreRepository<Product, ApplicationDbContext>, IProductRepository
    {
        public EfProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}