using System.ComponentModel.DataAnnotations;
using Domain;
using System.Collections.Generic;

namespace LicenseManagerWeb.ViewModels
{
    public class ViProtectionInfoViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Password { get; set; }
        public int ProductId { get; set; }
        public List<ViProtection> ViProtectionList { get; set; }
        public ViProtection ViProtection { get; set; }

        public ViProtectionInfoViewModel()
        {
            ViProtectionList = new List<ViProtection>();
        }
    }
}
