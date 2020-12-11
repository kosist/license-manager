using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain;
using LicenseManagerWeb.ViewModels;
using DAL.Repositories;

namespace LicenseManagerWeb.Controllers
{
    public interface IBaseController<TDomain, TDetailsViewModel, TEditViewModel, TRepo>
        where TDomain           :   BaseItem
        where TDetailsViewModel :   BaseViewModel, new()
        where TEditViewModel    :   BaseViewModel, new()
        where TRepo             :   IGenericItemRepository<BaseItem>
    {
        [HttpGet] public IActionResult Edit(int? id);
        [HttpPost] public IActionResult Edit(TDomain entity);
        [HttpGet] public IActionResult Details(int? id);
    }
}
