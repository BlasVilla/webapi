using System;

namespace AcademySample.Models
{
    public class UsageData
    {
        public Guid UsageDataId { get; set; }

        public int CpuUsage { get; set; }

        public int MemoryUsage { get; set; }

        public int AvailableDiskSpace { get; set; }

        public DateTime TimeStamp { get; set; }

        public string ComputerName { get; set; }
        
        #region Dependencies

        public ComputerDetails ComputerDetails { get; set; }

        #endregion
    }
}