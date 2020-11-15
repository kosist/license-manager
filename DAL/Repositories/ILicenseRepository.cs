using Domain;

namespace DAL.Repositories
{
    public interface ILicenseRepository<T> : IGenericItemRepository<T>
                    where T : License
    {
        
    }
}