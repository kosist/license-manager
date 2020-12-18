using System.Threading.Tasks;
using Domain;

namespace DAL.Repositories
{
    public interface IProjectRepository : IGenericItemRepository<Project>
    {
        Task AddProductToProject(int projectId, Product product);
    }
}