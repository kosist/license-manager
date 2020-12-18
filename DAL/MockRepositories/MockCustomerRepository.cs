using DAL.Repositories;
using System.Threading.Tasks;
using Domain;

namespace DAL.MockRepositories
{
    public class MockCustomerRepository : GenericMockRepository<Customer>, ICustomerRepository
    {
        public MockCustomerRepository() : base()
        {
            Task.Run(async () => await CreateCustomersList());
        }

        private async Task CreateCustomersList()
        {
            var customer1 = new Customer
            {
                Id = 0,
                Address = "Dummy address",
                Country = "Dummy country",
                Name = "Dummy customer"
            };

            await Insert(customer1);
        }

    }
}