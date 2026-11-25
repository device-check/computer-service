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

        public async Task ExecuteAsync(Guid id)
        {
            // pre-contract
            if (Guid.Empty == id)
                throw new ApplicationLayerException("Cannot delete a computer physical location with invalid ID.");

            await _computerPhysicalLocationRepository.DeleteAsync(id);
        }
    }
}
