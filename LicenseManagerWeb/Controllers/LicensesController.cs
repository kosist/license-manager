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

        public IActionResult Index()
        {
            return View(_licenseRepo.GetList());
        }

        public IActionResult Details(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("Id", "License id is less than 0");
            var license = _licenseRepo.GetById(id);
            return View(license);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                var usbTokenViewModel = new UsbTokenViewModel();
                return View(usbTokenViewModel.UsbToken);
            }

            var license = _licenseRepo.GetById(id);
            if (license == null)
            {
                return NotFound();
            }
            return View(license);
        }

        [HttpPost]
        public IActionResult Edit(UsbTokenLicense license)
        {
            if (ModelState.IsValid)
            {
                if (_licenseRepo.GetById(license.Id) == null)
                {
                    _licenseRepo.Insert(license);
                }
                else
                    _licenseRepo.Update(license);
                //return RedirectToAction("Details", "Licenses", new { id = license.Id });
                return RedirectToAction("Index");
            }
            else
            {
                return ValidationProblem();
            }
        }
    }
}
