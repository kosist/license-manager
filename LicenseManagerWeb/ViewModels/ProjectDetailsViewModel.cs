using System.ComponentModel;
using System.Collections.Generic;

namespace LicenseManagerWeb.ViewModels
{
    public class ProjectDetailsViewModel
    {
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Products List")]
        public IEnumerable<string> SwProjectNames { get; set; }

        public int? ProjectId { get; set; }
    }
}
