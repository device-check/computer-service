using System.Net;
using System.Net.NetworkInformation;

namespace domain
{
    public class Computer
    {
        private Guid id_computer = new Guid();
        private Guid id_computer_type;
        private Guid id_support;
        private Guid id_computer_physical_location;
        private PhysicalAddress _computerMacAddress;
        private IPAddress _computerIpv4Address;
        private bool? _computerIsPoweredOn;
        private ComputerType _computerType;
        private ComputerPhysicalLocation _computerPhysicalLocation;

        public Computer()
        {
            // E.F Core
        }


        public Computer(
            Guid id_computer_type, 
            Guid id_support, 
            Guid id_computer_physical_location, 
            PhysicalAddress computerMacAddress,
            IPAddress computerIpv4Address)
        {
            //

        }

    }
}
