using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UsbTokenApi : BaseItem

    {
        [DisplayName("HW Version")]
        [Required]
        public string HwVersion { get; set; } = "1.04";

        [DisplayName("SW Version")]
        [Required]
        public string SwVersion { get; set; } = "1.24";

        [DisplayName("API Version")]
        [Required]
        public string ApiVersion { get; set; } = "2.28";
    }
}