using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.ComputerPhysicalLocationUseCases
{
    public class GetComputerPhysicalLocationUseCase
    {
        private readonly IComputerPhysicalLocationRepository _computerPhysicalLocationRepository;

        public GetComputerPhysicalLocationUseCase(IComputerPhysicalLocationRepository computerPhysicalLocationRepository)
        {
            _computerPhysicalLocationRepository = computerPhysicalLocationRepository;
        }

        public async Task<List<ComputerPhysicalLocation>> ExecuteAsync(int page, int pageSize)
        {
            return await _computerPhysicalLocationRepository.GetAsync(page, pageSize);
        }

        public async Task<ComputerPhysicalLocation?> ExecuteAsync(Guid id)
        {
            // pre-contract
            if (id == Guid.Empty)
                throw new ApplicationLayerException("Computer physical location id must be valid.");

            return await _computerPhysicalLocationRepository.GetByIdAsync(id);
        }
    }
}
