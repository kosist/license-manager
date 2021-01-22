using System.ComponentModel;

namespace LicenseManagerWeb.DTOs
{
    /// <summary>
    /// This class is needed in order to have light-weight object to be used for list displaying.
    /// Also, DisplayName is set for Id field - this would be not logical for "main" class
    /// </summary>
    public class ProjectsListDto
    {
        [DisplayName("Project")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}