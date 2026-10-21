using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.BuildingUseCases
{
    public class AddBuildingUseCase
    {
        private readonly IBuildingRepository _buildingRepository;

        public AddBuildingUseCase(IBuildingRepository buildingUseCase)
        {
            _buildingRepository = buildingUseCase;
        }

        public async Task ExecuteAsync(Building building)
        {
            // pré-contract
            if (building is null)
                throw new ApplicationLayerException("Cannot adding a null building.");

            await _buildingRepository.AddAsync(building);
        }
    }
}
