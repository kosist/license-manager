using System;
using DAL.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManagerWeb.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _productRepo;

        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            return View(_productRepo.GetList());
        }

        public IActionResult Details(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("Id", "Product id is less than 0");
            var product = _productRepo.GetById(id);
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Update(product);
                return RedirectToAction("Details", "Products", new { id = product.Id});
            }
            else
            {
                return ValidationProblem();
            }
                
        }
    }
}