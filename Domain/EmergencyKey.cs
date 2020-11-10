namespace Domain
{
    public class EmergencyKey : BaseItem
    {
        public string Key { get; set; }
        public int ExecutionIntervalMinutes { get; set; }
    }
}