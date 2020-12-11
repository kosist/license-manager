using System;
using Microsoft.AspNetCore.Mvc;
using Domain;
using LicenseManagerWeb.ViewModels;
using DAL.Repositories;

namespace LicenseManagerWeb.Controllers
{
    public class BaseController<TDomain, TDetailsViewModel, TEditViewModel, TRepo> : Controller, IBaseController<TDomain, TDetailsViewModel, TEditViewModel, TRepo>
        where TDomain : BaseItem
        where TDetailsViewModel : BaseViewModel<TDomain>, new()
        where TEditViewModel : BaseViewModel<TDomain>, new()
        where TRepo : IGenericItemRepository<TDomain>
    {
        private IGenericItemRepository<TDomain> _repo;

        public BaseController(IGenericItemRepository<TDomain> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetList());
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
    }
}
