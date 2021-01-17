using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain;

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

        public ICollection<UserProject> UserProjects { get; set; }
    }
}
