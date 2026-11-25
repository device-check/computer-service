using application.Interfaces;
using domain.Entities;
using shared_kernel.Exceptions.ApplicationLayerExceptions;

namespace application.UseCases.BuildingUseCases
{
    public class GetBuildingUseCase
    {
        private readonly IBuildingRepository _buildingRepository;

        public GetBuildingUseCase(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<List<Building>> ExecuteAsync(int page, int pageSize)
        {
            // pre-contract
            if (page == 0 || page < 0)
                throw new ApplicationLayerException("Page number must be greater than zero.");
            if (pageSize == 0 || pageSize < 0)
                throw new ApplicationLayerException("Page size number must be greater than zero.");

            return await _buildingRepository.GetAsync(page, pageSize);
        }

        public async Task<Building?> ExecuteAsync(Guid id)
        {
            // pré-contract
            if (id == Guid.Empty)
                throw new ApplicationLayerException("Building id must be valid.");

            return await _buildingRepository.GetByIdAsync(id);
        }
    }
}
