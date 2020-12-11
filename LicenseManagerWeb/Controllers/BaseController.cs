using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using LicenseManagerWeb.ViewModels;
using DAL.Repositories;

namespace LicenseManagerWeb.Controllers
{
    public class BaseController<TDomain, TDetailsViewModel, TEditViewModel, TRepo> : Controller, IBaseController<TDomain, TDetailsViewModel, TEditViewModel, TRepo>
        where TDomain : BaseItem
        where TDetailsViewModel : BaseViewModel, new()
        where TEditViewModel : BaseViewModel, new()
        where TRepo : IGenericItemRepository<BaseItem>
    {
        private IGenericItemRepository<BaseItem> _repo;

        public BaseController(IGenericItemRepository<BaseItem> repo)
        {
            _repo = repo;
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var entity = _repo.GetById(id);
            if (entity == null)
                return NotFound();

            var viewModel = new TDetailsViewModel
            {
                Entity = entity,
            };

            return View(viewModel);
        }

        public IActionResult Edit(int? id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(TDomain entity)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
