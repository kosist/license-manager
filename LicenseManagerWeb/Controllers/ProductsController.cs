using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            return View(await _productRepo.GetList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var swProductView = new SwProductDetailsViewModel();
            var product = await _productRepo.GetById(id);
            if (product == null)
                return NotFound();
            swProductView.SwProduct = product;
            swProductView.ViProtectionViewModel = new ViProtectionInfoViewModel();
            return View(swProductView);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var productViewModel = new SwProductViewModel();
            await productViewModel.PopulateTokensList(_licenseRepo);
            if (id == null)
            {
                return View(productViewModel);
            }

            var product = await _productRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            productViewModel.SwProduct = _mapper.Map<SwProductViewDto>(product);
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SwProductViewModel product)
        {
            
            if (ModelState.IsValid)
            {
                var newLicense = await _licenseRepo.GetById(product.SwProduct.LicenseId);
                var swProduct = _mapper.Map<Product>(product.SwProduct);
                if (newLicense != null)
                    swProduct.License = newLicense;
                if (_productRepo.GetById(product.SwProduct.Id) == null)
                {
                    await _productRepo.Insert(swProduct);
                }
                else
                    await _productRepo.Update(swProduct);
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return ValidationProblem();
            }
        }

        public async Task<IActionResult> EditViProtection(int? productId)
        {
            if (productId == null)
                return NotFound();
            var product = await _productRepo.GetById(productId);
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
        public async Task<IActionResult> EditViProtection(ViProtectionInfoViewModel newInfo)
        {
            var updViProtectionInfo = new ViProtection
            {
                Description = newInfo.Description,
                Password = newInfo.Password
            };
            if (newInfo.ProductId == null)
                return NotFound();
            var product = await _productRepo.GetById(newInfo.ProductId);
            if (product == null)
                return NotFound();

            product.ViProtectionInfo.Add(updViProtectionInfo);
            await _productRepo.Update(product);

            var viProtectionView = new ViProtectionInfoViewModel
            {
                ViProtectionList = product.ViProtectionInfo,
                ProductId = newInfo.ProductId
            };
            return View(viProtectionView);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveViProtectionInfo(int itemId, int? productId)
        {
            if (productId == null)
                return NotFound();
            var product = await _productRepo.GetById(productId);
            if (product == null)
                return NotFound();

            if (itemId <= product.ViProtectionInfo.Count - 1)
            {
                product.ViProtectionInfo.RemoveAt(itemId);
                await _productRepo.Update(product);
            }
            var viProtectionView = new ViProtectionInfoViewModel
            {
                ViProtectionList = product.ViProtectionInfo,
                ProductId = productId
            };
            return View("EditViProtection", viProtectionView);
        }

        public async Task<IActionResult> EditViProtectionInfo(int itemId, int? productId)
        {
            if (productId == null)
                return NotFound();
            var product = await _productRepo.GetById(productId);
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
        public async Task<IActionResult> EditViProtectionInfo(EditViProtectionInfoViewModel viProtectionInfo)
        {
            var itemId = viProtectionInfo.ItemId;
            if (viProtectionInfo.ProductId == null)
                return NotFound();
            var product = await _productRepo.GetById(viProtectionInfo.ProductId);
            if (product == null)
                return NotFound();

            if (itemId <= product.ViProtectionInfo.Count - 1)
            {
                product.ViProtectionInfo[itemId].Description = viProtectionInfo.Description;
                product.ViProtectionInfo[itemId].Password = viProtectionInfo.Password;
                await _productRepo.Update(product);
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