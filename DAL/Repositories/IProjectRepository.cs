using System.Collections.Generic;
using Domain;

namespace DAL.Repositories
{
    public interface IProjectRepository : IGenericItemRepository<Project>
    {
        void AddProductToProject(int projectId, Product product);
    }
}