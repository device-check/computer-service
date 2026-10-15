using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.ComputerPhysicalLocationUseCases
{
    public class DeleteComputerPhysicalLocationUseCase
    {
        private readonly IComputerPhysicalLocationRepository _computerPhysicalLocationRepository;

        public DeleteComputerPhysicalLocationUseCase(IComputerPhysicalLocationRepository computerPhysicalLocationRepository)
        {
            _computerPhysicalLocationRepository = computerPhysicalLocationRepository;
        }

        public async Task ExecuteAsync(ComputerPhysicalLocation computerPhysicalLocation)
        {
            // pre-contract
            if (computerPhysicalLocation is null)
                throw new ApplicationLayerException("Cannot delete a null computer physical location.");

            await _computerPhysicalLocationRepository.DeleteAsync(computerPhysicalLocation);
        }
    }
}
