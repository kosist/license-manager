using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
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
    }
}