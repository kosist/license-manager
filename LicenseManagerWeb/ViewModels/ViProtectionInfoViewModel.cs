using System.ComponentModel.DataAnnotations;
using Domain;
using System.Collections.Generic;

namespace LicenseManagerWeb.ViewModels
{
    public class ViProtectionInfoViewModel
    {
        //[Required]
        public string Description { get; set; }
        //[Required]
        public string Password { get; set; }
        public int ProductId { get; set; }
    }
}
