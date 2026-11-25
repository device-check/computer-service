using application.Interfaces;
using shared_kernel.Exceptions.ApplicationLayerExceptions;
using System.Net;
using System.Net.NetworkInformation;

namespace application.UseCases.ComputerUseCases
{
    public class UpdateComputerUseCase
    {
        private readonly IComputerRepository _computerRepository;

        public UpdateComputerUseCase(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public async Task ExecuteAsync(
            Guid id, 
            Guid? id_support, 
            Guid? id_computer_physical_location, 
            Guid? id_computer_type, 
            Guid? id_computer_power_status, 
            PhysicalAddress? computerMacAddress, 
            IPAddress? computerIpv4Address)
        {
            // pre-contract

            if (id == Guid.Empty)
                throw new ApplicationLayerException(
                    "Computer ID cannot be empty.");

            if (
                id_support is null &&
                id_computer_physical_location is null &&
                id_computer_type is null &&
                id_computer_power_status is null &&
                computerMacAddress is null &&
                computerIpv4Address is null
            )
                throw new ApplicationLayerException(
                    "At least one attribute must be provided for updating the computer.");

            await _computerRepository.UpdateAsync(
                id,
                id_support,
                id_computer_physical_location,
                id_computer_type,
                id_computer_power_status,
                computerMacAddress,
                computerIpv4Address);

        }        
    }
}
