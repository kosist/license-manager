using System;
using System.Collections.Generic;
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
            var swProductView = new SwProductDetailsViewModel();
            var product = _productRepo.GetById(id);
            swProductView.SwProduct = product;
            swProductView.ViProtectionViewModel = new ViProtectionInfoViewModel();
            return View(swProductView);
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
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(SwProductViewModel product)
        {
            
            if (ModelState.IsValid)
            {
                var newLicense = _licenseRepo.GetById(product.SwProduct.LicenseId);
                var swProduct = _mapper.Map<Product>(product.SwProduct);
                var viProtectionInfo = _productRepo.GetById(product.SwProduct.Id).ViProtectionInfo;
                swProduct.ViProtectionInfo = viProtectionInfo;
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

        [HttpPost]
        public IActionResult AddViProtectionInfo(ViProtectionInfoViewModel newInfo)
        {
            var protectionList = _productRepo.GetById(newInfo.ProductId).ViProtectionInfo;
            protectionList.Add(new ViProtection
            {
                Description = newInfo.Description,
                Password = newInfo.Password
            });
            return PartialView("_ViProtectionInfo", protectionList);
        }

        [HttpPost]
        public IActionResult RemoveViProtectionInfo(int itemId, int productId)
        {
            var protectionList = _productRepo.GetById(productId).ViProtectionInfo;
            protectionList.RemoveAt(itemId);
            return PartialView("_ViProtectionInfo", protectionList);
        }
    }
}