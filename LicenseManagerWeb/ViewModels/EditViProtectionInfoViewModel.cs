using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagerWeb.ViewModels
{
    public class EditViProtectionInfoViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Password { get; set; }
        public int? ProductId { get; set; }
        public int ItemId { get; set; }          
    }
}
