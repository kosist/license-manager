using System.ComponentModel.DataAnnotations;

namespace LicenseManagerWeb.ViewModels
{
    public class ViProtectionInfoViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Password { get; set; }
        public int ProductId { get; set; }
    }
}
