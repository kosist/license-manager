using System.Collections.Generic;
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
            var viProtection = new List<ViProtection>();
            viProtection.Add(new ViProtection{Id = 1, Description = "VI 01", Password = "123456789"});
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
                },
                License = new UsbTokenLicense
                {
                    Id = 1,
                    K0 = "K0 key",
                    K1 = "K1 key",
                    SerialNumber = "15789"
                },
                EmergencyKey = new EmergencyKey
                {
                    Id = 1,
                    Key = "12345",
                    ExecutionIntervalMinutes = 30
                },
                ViProtectionInfo = viProtection,
            };
            Insert(product);
        }
    }
}