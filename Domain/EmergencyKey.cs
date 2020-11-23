using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class EmergencyKey : BaseItem
    {
        [DisplayName("Emergency Key")]
        [MaxLength(5)]
        [MinLength(5)]
        public string Key { get; set; }

        [DisplayName("Execution interval, min.")]
        public int ExecutionIntervalMinutes { get; set; }

        [DisplayName("Is Active?")]
        public bool Active { get; set; }
    }
}