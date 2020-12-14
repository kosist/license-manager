using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using LicenseManagerWeb.DTOs;

namespace LicenseManagerWeb.ViewModels
{
    public class ProjectEditViewModel
    {
        public ProjectDto Project { get; set; }
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }

        public ProjectEditViewModel()
        {
            Customers = new List<Customer>();
        }
    }
}
