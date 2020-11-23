using System;
using AutoMapper;
using DAL.Repositories;
using Domain;
using LicenseManagerWeb.DTOs;
using Microsoft.AspNetCore.Mvc;
using LicenseManagerWeb.ViewModels;

namespace LicenseManagerWeb.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _productRepo;
        private ILicenseRepository<UsbTokenLicense> _licenseRepo;
        private IMapper _mapper;

        public ProductsController(IProductRepository productRepo,
                                  ILicenseRepository<UsbTokenLicense> licenseRepo,
                                  IMapper mapper)
        {
            _productRepo = productRepo;
            _licenseRepo = licenseRepo;
            _mapper = mapper;
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

            productViewModel.SwProduct = _mapper.Map<SwProductViewDto>(product);
            productViewModel.SwProduct.EmergencyKey = product.EmergencyKey;
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(SwProductViewModel product)
        {
            
            if (ModelState.IsValid)
            {
                var newLicense = _licenseRepo.GetById(product.SwProduct.LicenseId);
                var swProduct = _mapper.Map<Product>(product.SwProduct);
                if (newLicense != null)
                    swProduct.License = newLicense;
                if (_productRepo.GetById(product.SwProduct.Id) == null)
                {
                    _productRepo.Insert(swProduct);
                }
                else
                    _productRepo.Update(swProduct);
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return ValidationProblem();
            }
        }
    }
}