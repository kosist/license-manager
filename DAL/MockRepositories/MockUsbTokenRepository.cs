using System;
using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public class MockUsbTokenRepository : GenericMockRepository<UsbTokenLicense>, ILicenseRepository<UsbTokenLicense>
    {
        public MockUsbTokenRepository() : base()
        {
            CreateTokens();
        }

        private void CreateTokens()
        {
            var token = new UsbTokenLicense
            {
                Id = 1,
                Name = "USB Token 01",
                SerialNumber = "12377",
                IssueDate = DateTime.Now,
                IssuedBy = new User {Name = "Dummy Name", Surname = "Dummy Surname"},
                K0 = "0000 1111 2222 3333",
                K1 = "4444 5555 6666 7777",
                UsbTokenApi = new UsbTokenApi(),
            };
            Insert(token);
            var token1 = new UsbTokenLicense
            {
                Id = 2,
                Name = "USB Token 02",
                SerialNumber = "22222",
                IssueDate = DateTime.Now,
                IssuedBy = new User { Name = "Dummy Name", Surname = "Dummy Surname" },
                K0 = "9999 1111 2222 3333",
                K1 = "6666 5555 6666 7777",
                UsbTokenApi = new UsbTokenApi(),
            };
            Insert(token1);
        }
    }
}