using System.ComponentModel;

namespace Domain
{
    public class UsbTokenLicense : License
    {
        public string K0 { get; set; }
        public string K1 { get; set; }
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        public UsbTokenApi UsbTokenApi { get; set; }
    }
}