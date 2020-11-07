using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public class MockCustomerRepository : GenericMockRepository<Customer>, ICustomerRepository
    {
        public MockCustomerRepository() : base()
        {
            CreateCustomersList();
        }

        private void CreateCustomersList()
        {
            var customer1 = new Customer
            {
                Id = 0,
                Address = "Dummy address",
                Country = "Dummy country",
                Name = "Dummy customer"
            };

            Insert(customer1);
        }

    }
}