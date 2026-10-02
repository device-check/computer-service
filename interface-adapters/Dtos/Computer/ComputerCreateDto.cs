using interface_adapters.Dtos.ComputerPhysicalLocation;
using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.Computer
{
    public class ComputerCreateDto
    {      


        [Required(ErrorMessage="Mac Address is required.")]
        [StringLength(maximumLength:17, MinimumLength=12, ErrorMessage="Minimum length is 12 and maximum length is 17.")]
        public string ComputerMacAddress;

        [Required(ErrorMessage="Ipv4 address is required.")]
        [StringLength(maximumLength:15, MinimumLength=11, ErrorMessage = "Minimum length is 11 and maximum length is 15.")]
        [RegularExpression(@"^(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)$", ErrorMessage = "Invalid IPv4 address.")]
        public string ComputerIpv4Address;

        [Required(ErrorMessage="Id computer power status is required.")]
        public Guid IdComputerPowerStatus;

        [Required(ErrorMessage="Id computer type is required.")]
        public Guid IdComputerType;

        [Required(ErrorMessage="Id computer physical location is required.")]
        public Guid IdComputerPhysicalLocation;

        [Required(ErrorMessage="Id support is required.")]
        public Guid IdSupport;
    }
}