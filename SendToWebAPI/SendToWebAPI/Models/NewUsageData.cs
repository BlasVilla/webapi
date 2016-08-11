namespace SendToWebAPI.Models
{
    public class NewUsageData
    {
        public ushort HostId { get; set; }
        
        public string Name { get; set; }
        
        public States State { get; set; }
        
        public int VirtualProcessorCount { get; set; }
        
        public Memory VirtualMemory { get; set; }
    }
}