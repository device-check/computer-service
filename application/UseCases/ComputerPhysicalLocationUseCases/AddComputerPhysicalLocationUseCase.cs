using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.ComputerPhysicalLocationUseCases
{
    public class AddComputerPhysicalLocationUseCase
    {
        private readonly IComputerPhysicalLocationRepository _computerPhysicalLocationRepository;

        public AddComputerPhysicalLocationUseCase(IComputerPhysicalLocationRepository computerPhysicalLocationRepository)
        {
            _computerPhysicalLocationRepository = computerPhysicalLocationRepository;
        }

        public async Task ExecuteAsync(ComputerPhysicalLocation computerPhysicalLocation)
        {
            // pre-contract
            if (computerPhysicalLocation is null)
                throw new ApplicationLayerException("Cannot add a null computer physical location.");

            await _computerPhysicalLocationRepository.AddAsync(computerPhysicalLocation);
        }
    }
}
