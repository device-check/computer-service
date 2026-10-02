using interface_adapters.Dtos.ComputerPhysicalLocation;

namespace interface_adapters.Dtos.Computer
{
    public class ComputerReadDto
    {
        public string ComputerMacAddress;
        public string ComputerIpv4Address;
        public string ComputerPowerStatus;
        public string ComputerType;
        public ComputerPhysicalLocationReadDto ComputerPhysicalLocation;
    }
}
