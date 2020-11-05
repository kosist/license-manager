using System.Collections.Generic;
using System.Linq;
using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public class MockProjectRepository : IProjectRepository
    {
        private List<Project> _projects;

        public MockProjectRepository()
        {
            _projects = new List<Project>();
            CreateProjectsList();
        }

        private void CreateProjectsList()
        {
            var customer = new Customer
            {
                Id = 0, Address = "Dummy address", Country = "Dummy country", Name = "Dummy customer"
            };
            var proj1 = new Project {Customer = customer, Name = "Dummy project 1"};
            var proj2 = new Project {Customer = customer, Name = "Dummy project 2"};
            var proj3 = new Project {Customer = customer, Name = "Dummy project 3"};
            AddProject(proj1);
            AddProject(proj2);
            AddProject(proj3);
        }

        public IEnumerable<Project> GetProjectsList()
        {
            return _projects;
        }

        public void AddProject(Project project)
        {
            if (_projects.Count != 0)
            {
                var targetId = _projects.Max(p => p.Id);
                project.Id = +1;
            }
            _projects.Add(project);
        }

        public void AddProductToProject(int projectId, Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}