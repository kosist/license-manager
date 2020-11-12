using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product : BaseItem
    {
        [DisplayName("Product ID")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int ProductId { get; set; }
        
        [Required]
        public string Name { get; set; }
        public License License { get; set; }
        public EmergencyKey EmergencyKey { get; set; }

        [Required]
        public string Version { get; set; }
        public ProductMeta ProductMetadata { get; set; }
        public List<ProductChange> ProductChanges { get; set; }
        public List<ViProtection> ViProtectionInfo { get; set; }
    }
}