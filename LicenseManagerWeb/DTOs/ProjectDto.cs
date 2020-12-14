using System.Collections.Generic;
using System.ComponentModel;

namespace LicenseManagerWeb.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Customer")]
        public int CustomerId { get; set; }
        public List<int> SwProductIds { get; set; }
    }
}
