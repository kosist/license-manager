using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EFRepositories
{
    public class EfProjectRepository : GenericEfCoreRepository<Project, ApplicationDbContext>, IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public EfProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Project> GetById(int? id)
        {
            var project = await _context.Set<Project>().Include(p => p.Customer).FirstOrDefaultAsync(p => p.Id == id);
            return project;
        }

        public Task AddProductToProject(int projectId, Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}