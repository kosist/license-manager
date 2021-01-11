using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;
using LicenseManagerWeb.ViewModels;

namespace LicenseManagerWeb.Controllers
{
    public class LicensesController : Controller
    {
        private ILicenseRepository<UsbTokenLicense> _licenseRepo;

        public LicensesController(ILicenseRepository<UsbTokenLicense> licenseRepo)
        {
            _licenseRepo = licenseRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _licenseRepo.GetList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var license = await _licenseRepo.GetById(id);
            if (license == null)
                return NotFound();
            return View(license);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                var usbTokenViewModel = new UsbTokenViewModel();
                return View(usbTokenViewModel.UsbToken);
            }
            var license = await _licenseRepo.GetById(id);
            if (license == null)
            {
                return NotFound();
            }
            return View(license);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsbTokenLicense license)
        {
            if (ModelState.IsValid)
            {
                if (await _licenseRepo.GetById(license.Id) == null)
                {
                    await _licenseRepo.Insert(license);
                }
                else
                    await _licenseRepo.Update(license);
                return RedirectToAction("Index");
            }
            else
            {
                return ValidationProblem();
            }
        }
    }
}
