using System.ComponentModel.DataAnnotations;

namespace AcademySample.Models
{
    public class ComputerDetails
    {
        [Key]
        public string Name { get; set; }

        public string IpAddress { get; set; }

        public int Memory { get; set; }

        public string User { get; set; }
    }
}