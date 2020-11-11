using System.ComponentModel;

namespace Domain
{
    public class UsbTokenApi : BaseItem

    {
        [DisplayName("HW Version")]
        public string HwVersion { get; set; }

        [DisplayName("SW Version")]
        public string SwVersion { get; set; }

        [DisplayName("API Version")]
        public string ApiVersion { get; set; }
    }
}