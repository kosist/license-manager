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

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var swProductView = new SwProductDetailsViewModel();
            var product = _productRepo.GetById(id);
            if (product == null)
                return NotFound();
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

        public IActionResult EditViProtection(int? productId)
        {
            if (productId == null)
                return NotFound();
            var product = _productRepo.GetById(productId);
            if (product == null)
                return NotFound();
            var protectionList = product.ViProtectionInfo;
            var viProtectionView = new ViProtectionInfoViewModel
            {
                ViProtectionList = protectionList,
                ProductId = productId
            };
            return View(viProtectionView);
        }
        
        [HttpPost]
        public IActionResult EditViProtection(ViProtectionInfoViewModel newInfo)
        {
            var updViProtectionInfo = new ViProtection
            {
                Description = newInfo.Description,
                Password = newInfo.Password
            };
            if (newInfo.ProductId == null)
                return NotFound();
            var product = _productRepo.GetById(newInfo.ProductId);
            if (product == null)
                return NotFound();

            product.ViProtectionInfo.Add(updViProtectionInfo);
            _productRepo.Update(product);

            var viProtectionView = new ViProtectionInfoViewModel
            {
                ViProtectionList = product.ViProtectionInfo,
                ProductId = newInfo.ProductId
            };
            return View(viProtectionView);
        }

        [HttpPost]
        public IActionResult RemoveViProtectionInfo(int itemId, int? productId)
        {
            if (productId == null)
                return NotFound();
            var product = _productRepo.GetById(productId);
            if (product == null)
                return NotFound();

            if (itemId <= product.ViProtectionInfo.Count - 1)
            {
                product.ViProtectionInfo.RemoveAt(itemId);
                _productRepo.Update(product);
            }
            var viProtectionView = new ViProtectionInfoViewModel
            {
                ViProtectionList = product.ViProtectionInfo,
                ProductId = productId
            };
            return View("EditViProtection", viProtectionView);
        }

        public IActionResult EditViProtectionInfo(int itemId, int? productId)
        {
            if (productId == null)
                return NotFound();
            var product = _productRepo.GetById(productId);
            if (product == null)
                return NotFound();

            if (itemId < product.ViProtectionInfo.Count - 1)
                RedirectToAction("Details", product.Id);

            var viProtectionView = new EditViProtectionInfoViewModel
            {
                ProductId = productId,
                Description = product.ViProtectionInfo[itemId].Description,
                Password = product.ViProtectionInfo[itemId].Password,
                ItemId = itemId,
            };
            return View(viProtectionView);
        }

        [HttpPost]
        public IActionResult EditViProtectionInfo(EditViProtectionInfoViewModel viProtectionInfo)
        {
            var itemId = viProtectionInfo.ItemId;
            if (viProtectionInfo.ProductId == null)
                return NotFound();
            var product = _productRepo.GetById(viProtectionInfo.ProductId);
            if (product == null)
                return NotFound();

            if (itemId <= product.ViProtectionInfo.Count - 1)
            {
                product.ViProtectionInfo[itemId].Description = viProtectionInfo.Description;
                product.ViProtectionInfo[itemId].Password = viProtectionInfo.Password;
                _productRepo.Update(product);
            }

            var viProtectionView = new ViProtectionInfoViewModel
            {
                ViProtectionList = product.ViProtectionInfo,
                ProductId = viProtectionInfo.ProductId
            };
            return View("EditViProtection", viProtectionView);
        }

    }
}