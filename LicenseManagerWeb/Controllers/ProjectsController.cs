using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManagerWeb.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectRepository _projectRepo;

        public ProjectsController(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public IActionResult Index()
        {
            return View(_projectRepo.GetList());
        }

        public IActionResult New()
        {
            return View();
        }
    }
}