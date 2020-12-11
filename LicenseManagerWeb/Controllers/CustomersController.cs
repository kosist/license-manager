using DAL.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;
using LicenseManagerWeb.ViewModels;

namespace LicenseManagerWeb.Controllers
{
    public class CustomersController : BaseController<Customer, CustomerDetailsViewModel, CustomerDetailsViewModel, ICustomerRepository>
    {
        private ICustomerRepository _customerRepo;

        public CustomersController(ICustomerRepository customerRepo) : base(customerRepo)
        {
            _customerRepo = customerRepo;
        }

        //public IActionResult Index()
        //{
        //    return View(_customerRepo.GetList());
        //}

        public IActionResult EditCustomer(int? id)
        {
            var customer = new Customer();
            if (id == null)
                return View(new Customer());
            customer = _customerRepo.GetById(id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_customerRepo.GetById(customer.Id) == null)
                {
                    _customerRepo.Insert(customer);
                }
                else
                    _customerRepo.Update(customer);
                return RedirectToAction("Index");
            }
            else
            {
                return ValidationProblem();
            }
        }

        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //        return NotFound();
        //    var customer = _customerRepo.GetById(id);
        //    if (customer == null)
        //        return NotFound();

        //    var customerViewModel = new CustomerDetailsViewModel
        //    {
        //        Customer = customer,
        //    };

        //    return View(customerViewModel);
        //}

    }
}