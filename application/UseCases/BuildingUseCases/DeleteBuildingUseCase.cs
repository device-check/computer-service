using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.BuildingUseCases
{
    public class DeleteBuildingUseCase
    {
        private IBuildingRepository _buildingRepository;

        public DeleteBuildingUseCase(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task ExecuteAsync(Building building)
        {
            // pré-contract
            if (building is null)
                throw new ApplicationLayerException("Cannot deleting a null building");

            await _buildingRepository.DeleteAsync(building);
        }
    }
}
