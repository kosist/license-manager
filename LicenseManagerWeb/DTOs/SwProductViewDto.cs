using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace LicenseManagerWeb.DTOs
{
    public class SwProductViewDto
    {
        public int? Id { get; set; }

        [DisplayName("Product ID")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("USB Token")]
        [Required]
        public int LicenseId { get; set; }
        public EmergencyKey EmergencyKey { get; set; }

        [Required]
        public string Version { get; set; }
        public ProductMeta ProductMetadata { get; set; }
        public List<ProductChange> ProductChanges { get; set; }
        public List<ViProtection> ViProtectionInfo { get; set; }
        public int ProjectId { get; set; }
    }
}