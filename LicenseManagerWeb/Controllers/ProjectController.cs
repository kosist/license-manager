using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManagerWeb.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepo;

        public ProjectController(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public IActionResult Index()
        {
            return View(_projectRepo.GetProjectsList());
        }
    }
}