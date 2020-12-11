using Microsoft.AspNetCore.Mvc;
using Domain;
using LicenseManagerWeb.ViewModels;
using DAL.Repositories;

namespace LicenseManagerWeb.Controllers
{
    public interface IBaseController<TDomain, TDetailsViewModel, TEditViewModel, TRepo>
        where TDomain           :   BaseItem
        where TDetailsViewModel :   BaseViewModel<TDomain>, new()
        where TEditViewModel    :   BaseViewModel<TDomain>, new()
        where TRepo             :   IGenericItemRepository<TDomain>
    {
        [HttpGet] public IActionResult Edit(int? id);
        [HttpPost] public IActionResult Edit(TDomain entity);
        [HttpGet] public IActionResult Details(int? id);
    }
}
