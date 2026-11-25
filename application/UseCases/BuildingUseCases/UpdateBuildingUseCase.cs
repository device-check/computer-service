using application.Exceptions;
using application.Interfaces;
using domain.Entities;

namespace application.UseCases.BuildingUseCases
{
    public class UpdateBuildingUseCase
    {
        private readonly IBuildingRepository _buildingRepository;

        public UpdateBuildingUseCase(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task ExecuteAsync(Guid id, Building buildingModified)
        {
            //pre-contract
            if (Guid.Empty == id)
                throw new ApplicationLayerException("Cannot update a building with invalid ID.");
            if (buildingModified is null)
                throw new ApplicationLayerException("Cannot update a null building.");

            await _buildingRepository.UpdateAsync(id, buildingModified);
        }
    }
}
