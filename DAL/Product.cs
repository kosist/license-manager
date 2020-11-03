﻿using System.Collections.Generic;

namespace DAL
{
    public class Product : BaseItem
    {
        public int ProductId { get; set; }
        public string Version { get; set; }
        public ProductMeta ProductMetadata { get; set; }
        public List<ProductChange> ProductChanges { get; set; }
        public List<ViProtection> ViProtectionInfo { get; set; }
        public string EmergencyKey { get; set; }
    }
}