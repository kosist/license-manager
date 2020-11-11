using System.ComponentModel;

namespace Domain
{
    public class EmergencyKey : BaseItem
    {
        [DisplayName("Emergency Key")]
        public string Key { get; set; }

        [DisplayName("Execution interval, min.")]
        public int ExecutionIntervalMinutes { get; set; }
    }
}