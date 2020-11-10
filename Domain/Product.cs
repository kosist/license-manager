using System.Collections.Generic;

namespace Domain
{
    public class Product : BaseItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public License License { get; set; }
        public EmergencyKey EmergencyKey { get; set; }
        public string Version { get; set; }
        public ProductMeta ProductMetadata { get; set; }
        public List<ProductChange> ProductChanges { get; set; }
        public List<ViProtection> ViProtectionInfo { get; set; }
    }
}