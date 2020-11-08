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
                Id = 1,
                Name = "Dummy SW Product 00",
                Version = "Version 00.00",
                ProductMetadata = new ProductMeta
                {
                    Id = 1,
                    EasyProjectLink = "http:ep/1.com",
                    SharePointLink = "http:sp/1.com",
                    SmartSheetLink = "http:sm/1.com",
                    SourceCodeLocation = "http:git/1.com"
                }
            };
            Insert(product);
        }
    }
}