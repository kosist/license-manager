using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public class MockProductRepository : GenericMockRepository<Product>, IProductRepository
    {
        public MockProductRepository() : base()
        {
            CreateProductsList();
        }

        private void CreateProductsList()
        {
            var product = new Product
            {
                Id = 0,
                Name = "Dummy SW Product 00",
                Version = "Version 00.00",
            };
            Insert(product);
        }
    }
}