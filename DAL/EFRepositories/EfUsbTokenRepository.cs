using DAL.Repositories;
using Domain;

namespace DAL.EFRepositories
{
    public class EfUsbTokenRepository : GenericEfCoreRepository<UsbTokenLicense, ApplicationDbContext>, ILicenseRepository<UsbTokenLicense>
    {
        public EfUsbTokenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}