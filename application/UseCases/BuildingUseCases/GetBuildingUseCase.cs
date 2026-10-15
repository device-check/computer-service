using application.Exceptions;
using application.Interfaces;
using domain.Entities;

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
