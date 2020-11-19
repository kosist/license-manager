using System;
using DAL.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;
using LicenseManagerWeb.ViewModels;

namespace LicenseManagerWeb.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _productRepo;
        private ILicenseRepository<UsbTokenLicense> _licenseRepo;

        public ProductsController(IProductRepository productRepo, ILicenseRepository<UsbTokenLicense> licenseRepo)
        {
            _productRepo = productRepo;
            _licenseRepo = licenseRepo;
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

        public IActionResult Edit(int? id)
        {
            var productViewModel = new SwProductViewModel();
            productViewModel.PopulateTokensList(_licenseRepo);
            if (id == null)
            {
                return View(productViewModel);
            }

            var product = _productRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            productViewModel.SwProduct = product;
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(SwProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Update(product.SwProduct);
                return RedirectToAction("Details", "Products", new { id = product.SwProduct.Id });
            }
            else
            {
                return ValidationProblem();
            }
                
        }

    }
}