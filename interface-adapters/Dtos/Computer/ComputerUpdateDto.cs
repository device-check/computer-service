using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.NetworkInformation;

namespace interface_adapters.Dtos.Computer
{
    public class ComputerUpdateDto
    {        
        [StringLength(maximumLength: 17, MinimumLength = 12, ErrorMessage = "Minimum length is 12 and maximum length is 17.")]
        public string? ComputerMacAddress { get; set; }
        
        [StringLength(maximumLength: 15, MinimumLength = 11, ErrorMessage = "Minimum length is 11 and maximum length is 15.")]
        [RegularExpression(@"^(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)$", ErrorMessage = "Invalid IPv4 address.")]
        public string? ComputerIpv4Address { get; set; }
        
        public Guid? IdComputerPowerStatus { get; set; }
        
        public Guid? IdComputerType { get; set; }
        
        public Guid? IdComputerPhysicalLocation { get; set; }
        
        public Guid? IdSupport { get; set; }
    }
}
