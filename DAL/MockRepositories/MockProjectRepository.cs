using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DAL.Repositories;
using Domain;

namespace DAL.MockRepositories
{
    public class MockProjectRepository : GenericMockRepository<Project>, IProjectRepository
    {
        public MockProjectRepository() : base()
        {
            Task.Run(async () => await CreateProjectsList());
        }

        private async Task CreateProjectsList()
        {
            var customer = new Customer
            {
                Id = 0, Address = "Dummy address", Country = "Dummy country", Name = "Dummy customer"
            };
            var proj1 = new Project {Id = 1, Customer = customer, Name = "Dummy project 1"};
            var proj2 = new Project {Id = 2, Customer = customer, Name = "Dummy project 2"};
            var proj3 = new Project {Id = 3, Customer = customer, Name = "Dummy project 3"};
            await Insert(proj1);
            await Insert(proj2);
            await Insert(proj3);
        }

        public Task AddProductToProject(int projectId, Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}