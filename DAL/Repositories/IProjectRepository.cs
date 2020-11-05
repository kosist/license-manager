using System.Collections.Generic;
using Domain;

namespace DAL.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjectsList();
        void AddProject(Project project);
        void AddProductToProject(int projectId, Product product);
    }
}