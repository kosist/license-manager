using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LicenseManagerWeb.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Customer")]
        public int CustomerId { get; set; }
        public List<int> SwProductIds { get; set; }
    }
}
