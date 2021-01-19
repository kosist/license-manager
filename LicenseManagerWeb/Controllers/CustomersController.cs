using System.Threading.Tasks;
using DAL.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;
using LicenseManagerWeb.ViewModels;

namespace LicenseManagerWeb.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepository _customerRepo;

        public CustomersController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<IActionResult> Index()
        {
            var view = await _customerRepo.GetList();
            return View(view);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var customer = new Customer();
            if (id == null)
                return View(new Customer());
            customer = await _customerRepo.GetById(id);
            if (customer == null)
                return NotFound();
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Id == null)
                    await _customerRepo.Insert(customer);
                else if (await _customerRepo.GetById(customer.Id) == null)
                {
                    await _customerRepo.Insert(customer);
                }
                else
                    await _customerRepo.Update(customer);
                return RedirectToAction("Index"); 
            }
            else
            {
                return ValidationProblem();
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var customer = await _customerRepo.GetById(id);
            if (customer == null)
                return NotFound();

            var customerViewModel = new CustomerDetailsViewModel
            {
                Customer = customer,
            };

            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var customer = await _customerRepo.GetById(id);
            if (customer == null)
                return NotFound();
            await _customerRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}