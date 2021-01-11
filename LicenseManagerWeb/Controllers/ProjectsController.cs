using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Domain;
using LicenseManagerWeb.DTOs;
using LicenseManagerWeb.ViewModels;

namespace LicenseManagerWeb.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectRepository _projectRepo;
        private IMapper _mapper;
        private ICustomerRepository _customerRepo;

        public ProjectsController(IProjectRepository projectRepo,
                                  ICustomerRepository customerRepo,
                                  IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
            _customerRepo = customerRepo;
        }

        public IActionResult Index()
        {
            return View(_projectRepo.GetList());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var project = new Project();
            var customers = _customerRepo.GetList().Result.ToList();
            if (id == null)
                return View(new ProjectEditViewModel
                {
                    Project = new ProjectDto(),
                    Customers = customers,
                });

            project = await _projectRepo.GetById(id);
            if (project == null)
                return NotFound();
            
            var projectEditViewModel = new ProjectEditViewModel
            {
                Project = _mapper.Map<Project, ProjectDto>(project),
                Customers = customers,
            };
            return View(projectEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectEditViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                var existingProject = await _projectRepo.GetById(projectViewModel.Project.Id);
                if (existingProject == null)
                {
                    var newProject = new Project
                    {
                        Name = projectViewModel.Project.Name,
                        Customer = await _customerRepo.GetById(projectViewModel.Project.CustomerId),
                    };
                    await _projectRepo.Insert(newProject);
                }
                else
                {
                    var customer = await _customerRepo.GetById(projectViewModel.Project.CustomerId);
                    existingProject = _mapper.Map<ProjectDto, Project>(projectViewModel.Project);
                    existingProject.Customer = customer;
                    await _projectRepo.Update(existingProject);
                }
                
                return RedirectToAction("Index");
            }
            else
            {
                return ValidationProblem();
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var project = await _projectRepo.GetById(id);
            if (project == null)
                return NotFound();

            var projectDetailsViewModel = new ProjectDetailsViewModel
            {
                ProjectName = project.Name,
                CustomerName = project.Customer.Name,
                SwProjectNames = project.SwProducts?.Select(p => p.Name),
                ProjectId = project.Id,
            };

            return View(projectDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var project = await _projectRepo.GetById(id);
            if (project == null)
                return NotFound();
            else
                await _projectRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}