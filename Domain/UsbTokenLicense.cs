namespace Domain
{
    public class UsbTokenLicense : License
    {
        public string K0 { get; set; }
        public string K1 { get; set; }
        public string SerialNumber { get; set; }
        public UsbTokenApi UsbTokenApi { get; set; }
    }
}