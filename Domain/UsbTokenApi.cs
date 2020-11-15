using System.ComponentModel;

namespace Domain
{
    public class UsbTokenApi : BaseItem

    {
        [DisplayName("HW Version")] public string HwVersion { get; set; } = "1.04";

        [DisplayName("SW Version")] public string SwVersion { get; set; } = "1.24";

        [DisplayName("API Version")] public string ApiVersion { get; set; } = "2.28";
    }
}