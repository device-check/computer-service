using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.BuildingUseCases
{
    public class AddBuildingUseCase
    {
        private readonly IBuildingRepository _buildingUseCase;

        public AddBuildingUseCase(IBuildingRepository buildingUseCase)
        {
            _buildingUseCase = buildingUseCase;
        }

        public async Task ExecuteAsync(Building building)
        {
            // pré-contract
            if (building is null)
                throw new ApplicationLayerException("Cannot adding a null building.");

            await _buildingUseCase.AddAsync(building);
        }
    }
}
