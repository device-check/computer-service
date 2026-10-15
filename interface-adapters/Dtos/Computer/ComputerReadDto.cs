using interface_adapters.Dtos.ComputerPhysicalLocation;

namespace interface_adapters.Dtos.Computer
{
    public class ComputerReadDto
    {
        public string ComputerMacAddress { get; set; }
        public string ComputerIpv4Address { get; set; }
        public string ComputerPowerStatus { get; set; }
        public string ComputerType { get; set; }
        public ComputerPhysicalLocationReadDto ComputerPhysicalLocation { get; set; }
    }
}
