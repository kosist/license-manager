using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UsbTokenLicense : License
    {
        [Required]
        public string K0 { get; set; }

        [Required]
        public string K1 { get; set; }

        [DisplayName("Serial Number")]
        [Required]
        [StringLength(5)]
        public string SerialNumber { get; set; }

        public UsbTokenApi UsbTokenApi { get; set; }
    }
}