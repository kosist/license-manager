using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductMeta : BaseItem
    {
        [DisplayName("Source code location")]
        public string SourceCodeLocation { get; set; }
        [DisplayName("Sharepoint")]
        public string SharePointLink { get; set; }
        [DisplayName("EasyProject")]
        public string EasyProjectLink { get; set; }
        [DisplayName("Smartsheet")]
        public string SmartSheetLink { get; set; }

    }
}