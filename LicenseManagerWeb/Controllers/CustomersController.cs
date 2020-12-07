using DAL.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManagerWeb.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepository _customerRepo;

        public CustomersController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public IActionResult Index()
        {
            return View(_customerRepo.GetList());
        }

        public IActionResult Details(int id)
        {
            if (id > 0)
                return View(_customerRepo.GetById(id));
            else
                return NotFound()
        }

        public IActionResult EditCustomer(int id)
        {
            var customer = new Customer();
            if (id > 0)
            {
                customer = _customerRepo.GetById(id);
                if (customer == null)
                    customer = new Customer();
            }

            return View(customer);
        }


    }
}