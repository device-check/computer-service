using System.Net;
using System.Net.NetworkInformation;

namespace domain.Entities
{
    public class Computer
    {
        private Guid id_computer = Guid.NewGuid();
        private Guid id_computer_type;
        private Guid id_support;
        private Guid id_computer_physical_location;
        private Guid id_computer_power_status;
        private PhysicalAddress _computerMacAddress;
        private IPAddress _computerIpv4Address; 
        private ComputerPowerStatus _computerPowerStatus;
        private ComputerType _computerType;
        private ComputerPhysicalLocation _computerPhysicalLocation;

        private Computer()
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
            SetIdSupport(id_support);
            SetIdComputerType(id_computer_type);
            SetIdComputerPhysicalLocation(id_computer_physical_location);
            SetMacAddress(computerMacAddress);
            SetIpv4Address(computerIpv4Address);
        }

        public Guid GetId()
        {
            return id_computer;
        }

        public Guid GetIdSupport()
        {
            return id_support;
        }

        public ComputerType GetComputerType()
        {
            return _computerType;
        }

        public ComputerPhysicalLocation GetComputerPhysicalLocation()
        {
            return _computerPhysicalLocation;
        }

        public PhysicalAddress GetMacAddress()
        {
            return _computerMacAddress;
        }

        public IPAddress GetIpv4Address()
        {
            return _computerIpv4Address;
        }

        public ComputerPowerStatus GetPowerStatus()
        {
            return _computerPowerStatus;
        }

        private void SetIdComputerType(Guid idComputerType)
        {
            // Pré-contract
            if (Guid.Empty == id_support)
                throw new DomainException($"The computer must be linked a valid ID Computer Type.");

            id_computer_type = idComputerType;
        }

        private void SetIdSupport(Guid idSupport)
        {
            // Pré-contract
            if (Guid.Empty == id_support)
                throw new DomainException($"The computer must be linked a valid ID Support.");

            id_support = idSupport;
        }

        public void SetIdComputerPhysicalLocation(Guid idComputerPhysicalLocation)
        {
            // Pré-contract
            if (Guid.Empty == id_support)
                throw new DomainException($"The computer must be linked a valid ID Physical Location.");

            id_computer_physical_location = idComputerPhysicalLocation;
        }


        public void SetIpv4Address(IPAddress ipAddress)
        {
            // Pré-contract
            if (ipAddress is null)
                throw new DomainException($"{nameof(_computerIpv4Address)} cannot be null.");

            _computerIpv4Address = ipAddress;
        }

        public void SetMacAddress(PhysicalAddress physicalAddress)
        {
            // Pré-contract
            if (physicalAddress is null)
                throw new DomainException($"{nameof(_computerMacAddress)} cannot be null.");

            _computerMacAddress = physicalAddress;
        }
    }
}
