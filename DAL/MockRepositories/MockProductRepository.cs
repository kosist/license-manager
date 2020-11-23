using System.Collections.Generic;
using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public class MockProductRepository : GenericMockRepository<Product>, IProductRepository
    {
        private ILicenseRepository<UsbTokenLicense> _licenseRepo;

        public MockProductRepository(ILicenseRepository<UsbTokenLicense> licenseRepo) : base()
        {
            _licenseRepo = licenseRepo;
            CreateProductsList();
        }

        private void CreateProductsList()
        {
            var viProtection = new List<ViProtection>();
            viProtection.Add(new ViProtection{Id = 1, Description = "VI 01", Password = "123456789"});
            var product = new Product
            {
                Id = 1,
                ProductId = 1,
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
                License = _licenseRepo.GetById(2),
                EmergencyKey = new EmergencyKey
                {
                    Id = 1,
                    Key = "12345",
                    ExecutionIntervalMinutes = 30,
                    Active = true,
                },
                ViProtectionInfo = viProtection,
            };
            Insert(product);
        }
    }
}