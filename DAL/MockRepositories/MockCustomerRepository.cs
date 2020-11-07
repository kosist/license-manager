using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public class MockCustomerRepository : GenericMockRepository<Customer>, ICustomerRepository
    {
        
    }
}