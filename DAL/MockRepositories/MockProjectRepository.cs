using System.Collections.Generic;
using System.Linq;
using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public class MockProjectRepository : GenericMockRepository<Project>, IProjectRepository
    {
        public MockProjectRepository() : base()
        {
            CreateProjectsList();
        }

        private void CreateProjectsList()
        {
            var customer = new Customer
            {
                Id = 0, Address = "Dummy address", Country = "Dummy country", Name = "Dummy customer"
            };
            var proj1 = new Project {Id = 1, Customer = customer, Name = "Dummy project 1"};
            var proj2 = new Project {Id = 2, Customer = customer, Name = "Dummy project 2"};
            var proj3 = new Project {Id = 3, Customer = customer, Name = "Dummy project 3"};
            Insert(proj1);
            Insert(proj2);
            Insert(proj3);
        }

        public void AddProductToProject(int projectId, Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}