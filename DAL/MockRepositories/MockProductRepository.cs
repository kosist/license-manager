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
                    EasyProjectLink = "https://www.easyproject.cz/",
                    SharePointLink = "https://www.microsoft.com/en-us/microsoft-365/sharepoint/collaboration",
                    SmartSheetLink = "https://www.smartsheet.com/",
                    SourceCodeLocation = "https://github.com/"
                },
                License = new UsbTokenLicense
                {
                    Id = 1,
                    K0 = "K0 key",
                    K1 = "K1 key",
                    SerialNumber = "15789",
                    UsbTokenApi = new UsbTokenApi
                    {
                        ApiVersion = "0.1.1",
                        HwVersion = "1.2.2",
                        SwVersion = "2.3.3"
                    }
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