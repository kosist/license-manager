namespace Domain
{
    public class EmergencyKeyLicense : License
    {
        public string EmergencyKey { get; set; }
        public int ExecutionIntervalMinutes { get; set; }
    }
}