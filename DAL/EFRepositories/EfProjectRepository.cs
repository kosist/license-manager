using System.Threading.Tasks;
using DAL.Repositories;
using Domain;

namespace DAL.EFRepositories
{
    public class EfProjectRepository : GenericEfCoreRepository<Project, ApplicationDbContext>, IProjectRepository
    {
        public EfProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task AddProductToProject(int projectId, Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}