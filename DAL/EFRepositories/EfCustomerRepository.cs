using DAL.Repositories;
using Domain;

namespace DAL.EFRepositories
{
    public class EfCustomerRepository : GenericEfCoreRepository<Customer, ApplicationDbContext>, ICustomerRepository
    {
        public EfCustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}