using DAL.EFRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UnitTests
{
    public class SqlLocalServerCustomerControllerTest : CustomersControllerTest
    {
        public SqlLocalServerCustomerControllerTest() : 
            base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testDB;Integrated Security=True")
            .Options)
        {
        }
    }
}